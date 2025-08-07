using System.Net;
using Microsoft.Extensions.Logging;
using OneCIntegration.OData;
using StandardODATA;

namespace OneCIntegration.Console;

/// <summary></summary>
public class ODataExamples
{
    private ODataService CreateODataService()
    {
        // надо установить переменные до запуска setx ONEC_USER "???"
        var user = Environment.GetEnvironmentVariable("ONEC_USER")!;
        var password = Environment.GetEnvironmentVariable("ONEC_PASSWORD")!;
        var serviceURL = Environment.GetEnvironmentVariable("ONEC_URL")! + "/odata/standard.odata/";
        var logger = LoggerFactory
            .Create(builder => builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Debug))
            .CreateLogger<ODataService>();
        // создаем HttpClient
        var handler = new HttpClientHandler
        {
            Credentials = new NetworkCredential(user, password),
            MaxRequestContentBufferSize = int.MaxValue,
        };
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(serviceURL),
            MaxResponseContentBufferSize = int.MaxValue
        };

        // создаем сервис
        return new ODataService(
            client: httpClient,
            serviceURL: serviceURL,
            logger: logger)
        {};
    }

    /// <summary></summary>
    public async Task GetData()
    {
        // пример реализован через простой сервис odata, 
        // вместо него можно использовать любые библиотеки, типа Microsoft.OData.Client, Simple.OData.Client и т.п. 
        // создаем сервис обмена
        var odataService = CreateODataService();
        // получаем данные из 1С
        var items = await odataService.Of<Catalog_Номенклатура>()
            .Expand(e => e.ВидНоменклатуры.СтавкаНДС)
            .FilterEquals(e => e.ВидНоменклатуры.Description, "Провода")
            .ToList();
    }
}
