using System.Text.Json.Serialization;

namespace MarcAiAPI.Domain.Entities.Store
{
    public class MarketplaceEntity
    {
        public long MarketplaceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    
        [JsonIgnore]
        public ICollection<StoreEntity>? Stores { get; set; }
    }
}