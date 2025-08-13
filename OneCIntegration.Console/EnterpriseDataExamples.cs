using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using OneCIntegration.Console.Models;
using OneCIntegration.EnterpriseData;

namespace OneCIntegration.Console;

/// <summary></summary>
public class EnterpriseDataExamples
{
    // Создаем для версии EnterpriseData 1.19, больше версия нигде не прописывается, только при создании
    private EnterpriseDataExchange<T> CreateEnterpriseDataExchange<T, TBody>()
        where T : EnterpriseData1_19.Message, new()
        where TBody: EnterpriseData1_19.Body, new()
    {
        // надо установить переменные до запуска setx ONEC_USER "???"
        var user = Environment.GetEnvironmentVariable("ONEC_USER")!;
        var password = Environment.GetEnvironmentVariable("ONEC_PASSWORD")!;
        var serviceURL = Environment.GetEnvironmentVariable("ONEC_URL")! + "/ws/EnterpriseDataExchange_1_0_1_1.1cws";
        var logger = LoggerFactory
            .Create(builder => builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Debug))
            .CreateLogger<EnterpriseDataExchange<T>>();
        var messageHelper = new EnterpriseData1_19.MessageHelper<T, TBody>(
            ownPeerCode: "ЦП",
            otherPeerCode: "ЦБ",
            exchangePlanName: "СинхронизацияДанныхЧерезУниверсальныйФормат"
        );
        return new EnterpriseDataExchange<T>(
            client: EnterpriseDataClientFactory.CreateBasic(serviceURL, user, password),
            serviceURL: serviceURL,
            messageHelper: messageHelper,
            logger: logger)
        {
            ExchangePath = Path.Combine(@"C:\files\1c", Guid.NewGuid().ToString()),
            DeleteExchangePathOnDispose = false,
            DeleteExchangePathAfterExchange = false
            //PartSize = 1
        };
    }

    // Создаем для версии EnterpriseData 1.19, больше версия нигде не прописывается, только при создании
    private EnterpriseDataExchange<EnterpriseData1_19.Message> CreateEnterpriseDataExchange()
    {
        return CreateEnterpriseDataExchange<EnterpriseData1_19.Message, EnterpriseData1_19.Body>();
    }

    /// <summary>Получить данные и подтвердить получение</summary>
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

    /// <summary>Изменить данные</summary>
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

    /// <summary>Получить данные с кастомным полем</summary>
    public async Task GetDataWithCustomFields()
    {
        // Игнорируем все переопределяемые свойства
        var overrides = new XmlAttributeOverrides();
        var baseAttributes = new XmlAttributes
        {
            XmlIgnore = true
        };
        overrides.Add(typeof(EnterpriseData1_19.СправочникПодразделения), nameof(EnterpriseData1_19.СправочникПодразделения.КлючевыеСвойства), baseAttributes);
        overrides.Add(typeof(EnterpriseData1_19.Body), nameof(EnterpriseData1_19.Body.Подразделения), baseAttributes);
        overrides.Add(typeof(EnterpriseData1_19.Message), nameof(EnterpriseData1_19.Message.Body), baseAttributes);

        // создаем сервис обмена
        await using var enterpriseDataExchange = CreateEnterpriseDataExchange<MessageCustom, BodyCustom>();
        enterpriseDataExchange.XmlAttributeOverrides = overrides;
        // получаем сообщение из 1С
        var message = await enterpriseDataExchange.GetDataFrom1C();
        // что-то делаем с данными
        var items = message.Body?.Подразделения;
        // отсылаем уведомление для 1С, что данные приняты и обработаны
        // для простоты номер сообщения равен входящему, в реальности должен браться из какого-то счетчика
        var messageNo = enterpriseDataExchange.MessageHelper.GetMessageNo(message);
        await enterpriseDataExchange.PutConfirmationTo1C(message, messageNo);
    }
}
