using System.Text.Json.Serialization;

namespace MarcAiAPI.Domain.Models.AI
{
    public class AIClassificationResult
    {
        [JsonPropertyName("sorted_stores")]
        public List<StoreDataForAI> SortedStores { get; set; } = new();    }
}