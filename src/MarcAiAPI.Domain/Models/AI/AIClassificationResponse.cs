using System.Text.Json.Serialization;

namespace MarcAiAPI.Domain.Models.AI
{
    public class AIClassificationResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
    
        [JsonPropertyName("result")]
        public AIClassificationResult? Result { get; set; }
    
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}