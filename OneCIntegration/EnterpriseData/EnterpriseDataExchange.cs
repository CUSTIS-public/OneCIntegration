using System.IO.Compression;
using System.Xml.Serialization;
using OneCIntegration.Utils;
using ServiceReference;
using Microsoft.Extensions.Logging;

namespace OneCIntegration.EnterpriseData;

/// <summary>Сервис обмена с 1С через EnterpriseData</summary>
public class EnterpriseDataExchange<T> : IAsyncDisposable, IDisposable
    where T : class
{
    private EnterpriseDataExchange_1_0_1_1PortTypeClient _client;
    private readonly string _serviceURL;
    private readonly string _ownPeerCode;
    private readonly string _otherPeerCode;
    private readonly string _exchangePlanName;

    /// <summary>Размер порции обмена, к</summary>
    public decimal PartSize { get; set; } = 1024;

    /// <summary>Задержка между проверками готовности данных</summary>
    public TimeSpan AttemptTimeout { get; set; } = TimeSpan.FromSeconds(3);

    private readonly ILogger<EnterpriseDataExchange<T>> _logger;

    public readonly BaseMessageHelper<T> MessageHelper;

    /// <summary>Папка с файлами обмена, по умолчанию создается во временной директории</summary>
    public string ExchangePath { get; set; }

    /// <summary>Удалить папку с файлами обмена в конце обмена (dispose)</summary>
    public bool DeleteExchangePath { get; set; } = true; 

    public EnterpriseDataExchange(EnterpriseDataExchange_1_0_1_1PortTypeClient client,
        string serviceURL,
        BaseMessageHelper<T> messageHelper,
        ILogger<EnterpriseDataExchange<T>> logger)
    {
        _client = client;
        _logger = logger;
        MessageHelper = messageHelper;
        ExchangePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        _serviceURL = serviceURL;
        _ownPeerCode = MessageHelper.OwnPeerCode;
        _otherPeerCode = MessageHelper.OtherPeerCode;
        _exchangePlanName = MessageHelper.ExchangePlanName;
    }

    public async ValueTask DisposeAsync()
    {
        if (_client != null) await _client.CloseAsync();
        DeleteExchangeDirectory();
    }

    public void Dispose()
    {
        if (_client != null) _client.Close();
        DeleteExchangeDirectory();
    }

    private void DeleteExchangeDirectory()
    {
        if (DeleteExchangePath && Directory.Exists(ExchangePath))
        {
            Directory.Delete(ExchangePath, recursive: true);
        }
    }

    private async Task Ping()
    {
        var result = await _client.PingAsync();
    }

    private async Task TestConnection()
    {
        await Ping();
        var result = (await _client.TestConnectionAsync(new TestConnectionRequest(_exchangePlanName, _ownPeerCode))).@return;
        if (!result)
            throw new OneCIntergationException($"Соединение не установлено. Сервер: [{_serviceURL}], exchangePlanName: [{_exchangePlanName}], peerCode: [{_ownPeerCode}]");
    }

    private void CheckError(string errorMessage, string methodName)
    {
        if (errorMessage != string.Empty)
        {
            throw new OneCIntergationException($"Ошибка в методе {methodName}: {errorMessage}");
        }
    }

    private async Task<List<string>> GetDataFromWebServiceInternal(string fileName)
    {
        var files = new List<string>();
        await TestConnection();

        var prepareDataForGettingResult = await _client.PrepareDataForGettingAsync(new PrepareDataForGettingRequest(_exchangePlanName, _ownPeerCode, PartSize));
        CheckError(prepareDataForGettingResult.ErrorMessage, "PrepareDataForGetting");
        var operationId = prepareDataForGettingResult.OperationID;

        PrepareDataOperationResult prepareDataOperationResult;
        while (true)
        {
            var prepareDataActionResult = await _client.PrepareDataActionResultAsync(new PrepareDataActionResultRequest(operationId));
            CheckError(prepareDataActionResult.ErrorMessage, "PrepareDataActionResult");
            prepareDataOperationResult = prepareDataActionResult.@return;
            if (prepareDataOperationResult.Status != "Active") break;
            _logger.LogInformation("PrepareDataActionResult Status {Status}, waiting...", prepareDataOperationResult.Status);
            Thread.Sleep(AttemptTimeout);
        }
        _logger.LogInformation("PrepareDataActionResult Status {Status}", prepareDataOperationResult.Status);

        int partCount = prepareDataOperationResult.PartCount;
        for (int i = 1; i <= partCount; i++)
        {
            var getDataPartResult = await _client.GetDataPartAsync(new GetDataPartRequest(prepareDataOperationResult.FileID, i));
            CheckError(getDataPartResult.ErrorMessage, "GetDataPartResult");
            byte[] data = getDataPartResult.@return;
            string fileName2Save = (partCount == 1) ? fileName + ".zip" : fileName + "." + i.ToString("d3");
            File.WriteAllBytes(fileName2Save, data);
            files.Add(fileName2Save);
        }
        var confirmGettingFileResult = await _client.ConfirmGettingFileAsync(new ConfirmGettingFileRequest(prepareDataOperationResult.FileID, true));
        CheckError(confirmGettingFileResult.ErrorMessage, "ConfirmGettingFile");
        _logger.LogInformation("GetDataFromWebServiceInternal completed, files: {Files}", files.Count);
        return files;
    }

    private async Task PutDataToWebServiceInternal(string fileName)
    {
        await TestConnection();
        //если передано непосредственно имя ZIP-архива - читаем одним куском 
        bool singleFile = fileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase);
        string fileId = Guid.NewGuid().ToString();
        if (singleFile)
        {
            byte[] partData = System.IO.File.ReadAllBytes(fileName);
            //передаем 0 в качестве номера части файла
            var resultPutFilePart = await _client.PutFilePartAsync(new PutFilePartRequest(fileId, 0, partData));
            CheckError(resultPutFilePart.ErrorMessage, "PutFilePart");
        }
        else
        {
            //счетчик частей файла начинается с единицы
            int partNumber = 1;
            //считаем, что нам передали имя последовательности файлов (*.001, *.002 и т.д.) БЕЗ расширения и точки на конце
            string filePath = fileName + "." + (partNumber).ToString("d3");
            while (File.Exists(filePath))
            {
                byte[] partData = System.IO.File.ReadAllBytes(filePath);
                var resultPutFilePart = await _client.PutFilePartAsync(new PutFilePartRequest(fileId, partNumber, partData));
                CheckError(resultPutFilePart.ErrorMessage, "PutFilePart");
                filePath = fileName + "." + (++partNumber).ToString("d3");
            }
        }
        var putDataResult = await _client.PutDataAsync(new PutDataRequest(_exchangePlanName, _ownPeerCode, fileId));
        CheckError(putDataResult.ErrorMessage, "PutData");

        string putDataActionResultStatus;
        while (true)
        {
            var putDataActionResult = await _client.PutDataActionResultAsync(new PutDataActionResultRequest(putDataResult.OperationID));
            CheckError(putDataActionResult.ErrorMessage, "PutDataActionResult");
            putDataActionResultStatus = putDataActionResult.@return;
            if (putDataActionResultStatus != "Active") break;
            _logger.LogInformation("PutDataActionResult Status {Status}, waiting...", putDataActionResultStatus);
            Thread.Sleep(AttemptTimeout);
        }
        _logger.LogInformation("PutDataActionResult Status {Status}", putDataActionResultStatus);
        _logger.LogInformation("PutDataToWebServiceInternal completed");
    }

    private T ReadMessageFromFile(string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StreamReader(fileName);
        return (T)serializer.Deserialize(reader)!;
    }

    private void WriteMessageToFile(T message, string fileName)
    {
        var settings = new System.Xml.XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",
            NewLineChars = "\r\n",
            NewLineHandling = System.Xml.NewLineHandling.Replace
        };
        var serializer = new XmlSerializer(typeof(T));
        using var xmlWriter = System.Xml.XmlWriter.Create(fileName, settings);
        //using var customWriter = new CustomXmlWriter(xmlWriter);
        serializer.Serialize(xmlWriter, message);
    }

    #region Пути
    private string GetExchangePath()
    {
        if (string.IsNullOrEmpty(ExchangePath))
            throw new OneCIntergationException("Не задан путь к папке обмена (ExchangePath)");
        Directory.CreateDirectory(ExchangePath);
        return ExchangePath;
    }

    private string GetFrom1CPath()
    {
        var path = Path.Combine(GetExchangePath(), DateTime.Now.ToString("yyyyMMddHHmmss") + "_from1c_" + Guid.NewGuid().ToString());
        Directory.CreateDirectory(path);
        return path;
    }

    private string GetTo1CPath()
    {
        var path = Path.Combine(GetExchangePath(), DateTime.Now.ToString("yyyyMMddHHmmss") + "_to1c_" + Guid.NewGuid().ToString());
        Directory.CreateDirectory(path);
        return path;
    }

    private string GetDataPath(string basePath)
    {
        var path = Path.Combine(basePath, "data");
        Directory.CreateDirectory(path);
        return path;
    }
    #endregion

    /// <summary>Запросить и получить сообщение из 1С</summary>
    public async Task<T> GetDataFrom1C()
    {
        var basePath = GetFrom1CPath();
        var dataPath = GetDataPath(basePath);
        // получаем файлы из 1С
        var files = await GetDataFromWebServiceInternal(Path.Combine(basePath, "data"));
        // распакуем файл xml
        ZipHelper.ExtractToDirectory(files, Path.Combine(basePath, "data.zip"), dataPath);

        /*var dir = Path.Combine(Path.GetTempPath(), "0b0f900d-0ae3-4a3e-b166-eb767ada629b");
        var requestDir = Path.Combine(dir, "request");*/

        var message = ReadMessageFromFile(dataPath + @"\data.xml");

        return message;
    }

    /// <summary>Отослать сообщение в 1С</summary>
    /// <param name="message">Сообщение</param>
    public async Task PutDataTo1C(T message)
    {
        var basePath = GetTo1CPath();
        var dataPath = GetDataPath(basePath);
        WriteMessageToFile(message, dataPath + @"\data.xml");

        // Упакуем файл в zip
        var file = Path.Combine(basePath, "data.zip");
        ZipFile.CreateFromDirectory(dataPath, file);

        await PutDataToWebServiceInternal(file);
    }

    /// <summary>Отослать уведомление о получении (пустое сообщение)</summary>
    /// <param name="sourceMessage">Исходное сообщение</param>
    /// <param name="messageNo">Номер исходящего сообщения</param>
    public async Task PutConfirmationTo1C(T sourceMessage, string messageNo)
    {
        var message = MessageHelper.CreateMessage(MessageHelper.GetMessageNo(sourceMessage), messageNo);
        await PutDataTo1C(message);
    }
}