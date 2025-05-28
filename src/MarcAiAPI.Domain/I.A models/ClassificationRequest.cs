using System.Text.Json.Serialization;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.I.A_models;

public class ClassificationRequest
{
    [JsonPropertyName("preferences")]
    public List<string> Preferences { get; set; }
    
    [JsonPropertyName("stores")]
    public List<StoreInfo> Stores { get; set; }
}