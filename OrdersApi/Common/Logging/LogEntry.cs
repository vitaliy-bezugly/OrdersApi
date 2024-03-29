using Newtonsoft.Json;

namespace OrdersApi.Common.Logging;

public record LogEntry
{
    public string Class { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string? Operation { get; set; }
    public string Parameters { get; set; } = string.Empty;
    
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}