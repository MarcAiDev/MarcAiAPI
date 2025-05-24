using System.Text.Json.Serialization;
using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.User;

namespace MarcAiAPI.Domain.Entities.Store
{
    public class StoreEntity
    {
        public long StoreId { get; set; }
        public long SellerId { get; set; }
        public long MarketplaceId { get; set; }
        public string? Cnpj { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public string? Status { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }

        [JsonIgnore]
        public UserEntity? Seller { get; set; }
        [JsonIgnore]
        public StoreAddressEntity? StoreAddress { get; set; }
        [JsonIgnore]
        public MarketplaceEntity? Marketplace { get; set; }
    }
}