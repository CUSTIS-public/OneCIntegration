namespace OneCIntegration.EnterpriseData;

public abstract class BaseMessageHelper<T>
    where T : class
{
    public readonly string OwnPeerCode;
    public readonly string OtherPeerCode;
    public readonly string ExchangePlanName;

    protected abstract string Format { get; }

    protected readonly List<string> AvailableVersions;

    public BaseMessageHelper(string ownPeerCode, string otherPeerCode, string exchangePlanName,
        List<string> availableVersions)
    {
        OwnPeerCode = ownPeerCode;
        OtherPeerCode = otherPeerCode;
        ExchangePlanName = exchangePlanName;
        AvailableVersions = availableVersions;
    }

    public abstract T CreateMessage(string receivedNo, string messageNo);

    public abstract string GetMessageNo(T message);

    public abstract string GetReceivedNo(T message);
}