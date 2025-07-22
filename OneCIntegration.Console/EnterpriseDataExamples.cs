using Microsoft.Extensions.Logging;
using OneCIntegration.EnterpriseData;

namespace OneCIntegration.Console;

/// <summary></summary>
public class EnterpriseDataExamples
{
    // Создаем для версии EnterpriseData 1.1, больше версия нигде не прописывается, только при создании
    private EnterpriseDataExchange<EnterpriseData1_17.Message> CreateEnterpriseDataExchange()
    {
        // надо установить переменные до запуска setx ONEC_USER "???"
        var user = Environment.GetEnvironmentVariable("ONEC_USER")!;
        var password = Environment.GetEnvironmentVariable("ONEC_PASSWORD")!;
        var serviceURL = "http://inf-3cserver.office.custis.ru/ERPUH/ws/EnterpriseDataExchange_1_0_1_1.1cws";
        var logger = LoggerFactory
            .Create(builder => builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Debug))
            .CreateLogger<EnterpriseDataExchange<EnterpriseData1_17.Message>>();
        var messageHelper = new EnterpriseData1_17.MessageHelper(
            ownPeerCode: "ЦП",
            otherPeerCode: "ЦБ",
            exchangePlanName: "СинхронизацияДанныхЧерезУниверсальныйФормат"
        );
        return new EnterpriseDataExchange<EnterpriseData1_17.Message>(
            client: EnterpriseDataClientFactory.CreateNtlm(serviceURL, user, password),
            serviceURL: serviceURL,
            ownPeerCode: "ЦП",
            otherPeerCode: "ЦБ",
            exchangePlanName: "СинхронизацияДанныхЧерезУниверсальныйФормат",
            logger,
            messageHelper)
        {
            ExchangePath = Path.Combine(@"C:\files\1c", Guid.NewGuid().ToString()),
            RemoveExchangePath = false,
            PartSize = 1
        };
    }

    /// <summary></summary>
    public async Task GetDataWithСonfirmation()
    {
        // создаем сервис обмена
        await using var enterpriseDataExchange = CreateEnterpriseDataExchange();
        // получаем сообщение из 1С
        var message = await enterpriseDataExchange.GetDataFrom1C();
        // что-то делаем с данными
        var items = message.Body?.Номенклатура;
        // отсылаем уведомление для 1С, что данные приняты и обработаны
        // для простоты номер сообщения равен входящему, в реальности должен браться из какого-то счетчика
        var messageNo = enterpriseDataExchange.MessageHelper.GetMessageNo(message);
        await enterpriseDataExchange.PutConfirmationTo1C(message, messageNo);
    }

    /// <summary></summary>
    public async Task GetAndPutData()
    {
        await using var enterpriseDataExchange = CreateEnterpriseDataExchange();
        var message = await enterpriseDataExchange.GetDataFrom1C();
        // берем оба номера из входящего сообщения, в реальности исходящие номера должны сохраняться где-то, например, в БД
        var receivedNo = enterpriseDataExchange.MessageHelper.GetMessageNo(message);
        var messageNo = receivedNo;
        // если меняется Справочник.Номенклатура
        if (message.Body?.Номенклатура != null)
        {
            // ищем те, которые заканчиваются на " - test";
            var items = message.Body?.Номенклатура.Where(_ => _.КлючевыеСвойства?.Наименование?.EndsWith(" - test") == true).ToList();
            if (items?.Count > 0)
            {
                var responseMessage = enterpriseDataExchange.MessageHelper.CreateMessage(receivedNo, messageNo);
                responseMessage.Body = new EnterpriseData1_17.Body();
                items.ForEach(i =>
                {
                    i.КлючевыеСвойства.Наименование = i.КлючевыеСвойства.Наименование.Substring(0, i.КлючевыеСвойства.Наименование.Length - 7);
                });
                responseMessage.Body.Номенклатура = items;
                await enterpriseDataExchange.PutDataTo1C(responseMessage);
                return;
            }
        }

        // если еще не отослали сообщение с изменениями, то отсылаем просто уведомление, что сообщение получено
        await enterpriseDataExchange.PutConfirmationTo1C(message, messageNo);
    }
}
