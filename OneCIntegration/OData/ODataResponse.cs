using System.Text.Json.Serialization;

namespace OneCIntegration.OData;

public class ODataResponse<T>
{
    [JsonPropertyName("value")]
    public List<T> Value { get; set; }
}