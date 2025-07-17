namespace OneCIntegration;

public class OneCIntergationException : Exception
{
    public OneCIntergationException(string message) : base(message)
    { }
    
    public OneCIntergationException(string message, Exception innerException) : base(message, innerException)
    { }
}