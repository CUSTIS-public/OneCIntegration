using System.Net;
using System.ServiceModel;
using ServiceReference;

namespace OneCIntegration.EnterpriseData;

public static class EnterpriseDataClientFactory
{
    public static EnterpriseDataExchange_1_0_1_1PortTypeClient CreateNtlm(string serviceURL, string user, string password, string? domain = null)
    {
        var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
        binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
        var client = new EnterpriseDataExchange_1_0_1_1PortTypeClient(binding, new EndpointAddress(serviceURL));
        client.ClientCredentials.Windows.ClientCredential = new NetworkCredential
        {
            UserName = user,
            Password = password,
            Domain = domain
        };
        return client;
    }
}