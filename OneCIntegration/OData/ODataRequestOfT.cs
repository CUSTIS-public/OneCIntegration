using System.Linq.Expressions;

namespace OneCIntegration.OData;

public class ODataRequest<T> : ODataRequest
    where T : class
{
    private ODataService _service;
    public ODataRequest(ODataService service, string basePath)
        : base(basePath ?? $"{typeof(T).Name}")
    {
        _service = service;
    }
    public ODataRequest<T> Select(string select)
    {
        Selects.Add(select);
        return this;
    }
    public ODataRequest<T> Expand(string expand)
    {
        Expands.Add(expand);
        return this;
    }
    public ODataRequest<T> FilterRaw(string filter)
    {
        Filters.Add(filter);
        return this;
    }
    public ODataRequest<T> FilterRaw(Expression<Func<T, object>> property, string filter)
    {
        return FilterRaw($"{GetName(property)} {filter}");
    }
    private string GetValue(object value)
    {
        if (value == null) return "null";
        var a = value is string || value is Enum ? "'" : "";
        return $"{a}{Uri.EscapeDataString(value.ToString().Replace("'", "''"))}{a}";
    }
    public ODataRequest<T> Filter(Expression<Func<T, object>> property, string operatorString, object value)
    {
        return FilterRaw($"{GetName(property)} {operatorString} {GetValue(value)}");
    }
    public ODataRequest<T> FilterEquals(Expression<Func<T, object>> property, object value)
    {
        return Filter(property, "eq", value);
    }
    public ODataRequest<T> FilterContains<TK>(Expression<Func<T, object>> property, IEnumerable<TK> keys)
    {
        var name = GetName(property);
        return FilterRaw($"({string.Join(" or ", keys.Select(_ => $"{name} eq {GetValue(_)}"))})");
    }
    public ODataRequest<T> FilterContains(Expression<Func<T, object>> property, params object[] keys)
    {
        return FilterContains(property, (IEnumerable<object>)keys);
    }
    public ODataRequest<T> Expand(Expression<Func<T, object>> property)
    {
        return Expand($"{GetName(property)}");
    }
    public ODataRequest<T> Skip(long skip)
    {
        SkipValue = skip;
        return this;
    }
    public ODataRequest<T> Top(long top)
    {
        TopValue = top;
        return this;
    }
    public ODataRequest<T> OrderBy(string orderBy)
    {
        OrderByList.Add(orderBy);
        return this;
    }
    public ODataRequest<T> Additional(string additional)
    {
        AdditionalList.Add(additional);
        return this;
    }

    public async Task<List<T>> ToList()
    {
        return await _service.GetEntities<T>(ToString(), default);
    }
}