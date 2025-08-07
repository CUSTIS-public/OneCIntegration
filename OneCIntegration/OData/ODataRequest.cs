using System.Linq.Expressions;
using System.Text;
using OneCIntegration.Utils;

namespace OneCIntegration.OData;

public class ODataRequest
{
    public List<string> Selects { get; private set; } = new();
    public List<string> Expands { get; private set; } = new();
    public List<string> Filters { get; private set; } = new();
    public List<string> OrderByList { get; private set; } = new();
    public long? SkipValue { get; set; }
    public long? TopValue { get; set; }
    public List<string> AdditionalList { get; private set; } = new();
    public string BasePath { get; private set; }
    protected ODataRequest(string basePath = null)
    {
        BasePath = basePath;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(BasePath);
        sb.Append("?$format=json");
        if (Selects.Count > 0)
        {
            sb.Append("&$select=");
            sb.Append(string.Join(",", Selects));
        }
        if (Expands.Count > 0)
        {
            sb.Append("&$expand=");
            sb.Append(string.Join(",", Expands));
        }
        if (Filters.Count > 0)
        {
            sb.Append("&$filter=");
            sb.Append(string.Join(" and ", Filters));
        }
        if (OrderByList.Count > 0)
        {
            sb.Append("&$orderby=");
            sb.Append(string.Join(",", OrderByList));
        }
        if (SkipValue != null) sb.Append($"&$skip={SkipValue}");
        if (TopValue != null) sb.Append($"&$top={TopValue}");
        if (AdditionalList.Count > 0) sb.Append("&" + string.Join("&", AdditionalList));
        return sb.ToString();
    }
    public static ODataRequest Combine(ODataRequest request1, ODataRequest request2)
    {
        if (request1 == null) return request2;
        if (request2 == null) return request1;
        var request = request1.Clone();
        request.Selects.AddRange(request2.Selects);
        request.Expands.AddRange(request2.Expands);
        request.Filters.AddRange(request2.Filters);
        request.OrderByList.AddRange(request2.OrderByList);
        request.AdditionalList.AddRange(request2.AdditionalList);
        request.SkipValue = request.SkipValue ?? request2.SkipValue;
        request.TopValue = request.TopValue ?? request2.TopValue;
        request.BasePath = request.BasePath ?? request2.BasePath;
        return request;
    }
    public ODataRequest Clone()
    {
        return new ODataRequest
        {
            Selects = new List<string>(this.Selects),
            Expands = new List<string>(this.Expands),
            Filters = new List<string>(this.Filters),
            OrderByList = new List<string>(this.OrderByList),
            AdditionalList = new List<string>(this.AdditionalList),
            SkipValue = this.SkipValue,
            TopValue = this.TopValue,
            BasePath = this.BasePath
        };
    }
    
    /// <summary>Получение имени odata для выражения</summary>
    public static string GetName<T>(Expression<Func<T, object>> expression)
        where T : class
    {
        var members = ReflectionHelpers.GetMembers(expression);
        return string.Join("/", members);
    }
}
