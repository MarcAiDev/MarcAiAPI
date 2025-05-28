using System.Text.Json.Serialization;

namespace MarcAiAPI.Domain.I.A_models;

public class StoreInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; }
}