using System.Text.Json.Serialization;

namespace MarcAiAPI.Domain.Models.AI
{
    public class AIClassificationRequest
    {
        [JsonPropertyName("preferences")]
        public List<string> Preferences { get; set; } = new();
    
        [JsonPropertyName("stores")]
        public List<StoreDataForAI> Stores { get; set; } = new();
    }
}