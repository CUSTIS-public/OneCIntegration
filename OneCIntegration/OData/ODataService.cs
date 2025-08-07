using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace OneCIntegration.OData;

/// <summary>Сервис обмена с 1С через ODataService</summary>
public class ODataService
{
    private HttpClient _client;
    private readonly string _serviceURL;
    private readonly ILogger<ODataService> _logger;
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }

    /// <summary>ctor</summary>
    public ODataService(HttpClient client,
        string serviceURL,
        ILogger<ODataService> logger)
    {
        _client = client;
        _logger = logger;
        _serviceURL = serviceURL;
    }

    public async Task<List<T>> GetEntities<T>(string oDataQuery, CancellationToken token) where T : class
    {
        try
        {
            var json = await _client.GetStringAsync(oDataQuery, token);
            var response = JsonSerializer.Deserialize<ODataResponse<T>>(json, JsonSerializerOptions);
            if (response == null)
                throw new OneCIntergationException($"Не удалось получить {typeof(T).Name.ToLower()} из внешнего источника odata {_serviceURL}");
            return response.Value;
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new HttpRequestException($"Неверный запрос odata {oDataQuery}", e);
            }
            else
            {
                throw;
            }
        }
    }

    public ODataRequest<T> Of<T>()
        where T : class
    {
        return new ODataRequest<T>(this, typeof(T).Name);
    }
}