using OneCIntegration.EnterpriseData;

namespace OneCIntegration.EnterpriseData1_17;

public class MessageHelper<T, TBody> : BaseMessageHelper<T>
    where T : Message, new()
    where TBody: Body, new()
{
    protected override string Format => "http://v8.1c.ru/edi/edi_stnd/EnterpriseData/1.17";

    public static List<string> DefaultAvailableVersions =
        [
            "1.8",
            "1.7",
            "1.17",
            "1.16",
            "1.15",
            "1.12",
            "1.11",
            "1.10"
        ];

    public MessageHelper(string ownPeerCode, string otherPeerCode, string exchangePlanName, List<string>? availableVersions = null)
        : base(ownPeerCode, otherPeerCode, exchangePlanName, availableVersions ?? DefaultAvailableVersions)
    {
    }

    public override T CreateMessage(string receivedNo, string messageNo)
    {
        var message = new T();
        message.Header = new Header();
        message.Header.Format = Format;
        message.Header.CreationDate = DateTime.Now;
        message.Header.AvailableVersion = AvailableVersions;
        message.Header.Confirmation = new Confirmation
        {
            ExchangePlan = ExchangePlanName,
            To = OtherPeerCode,
            From = OwnPeerCode,
            ReceivedNo = receivedNo,
            MessageNo = messageNo
        };
        message.Body = new TBody();
        return message;
    }

    public override string GetMessageNo(T message)
    {
        return message.Header.Confirmation.MessageNo;
    }

    public override string GetReceivedNo(T message)
    {
        return message.Header.Confirmation.ReceivedNo;
    }
}

public class MessageHelper : MessageHelper<Message, Body>
{
    public MessageHelper(string ownPeerCode, string otherPeerCode, string exchangePlanName, List<string>? availableVersions = null)
        : base(ownPeerCode, otherPeerCode, exchangePlanName, availableVersions)
    {
    }
}