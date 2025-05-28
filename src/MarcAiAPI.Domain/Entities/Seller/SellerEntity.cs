using System.Text.Json.Serialization;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Entities.User;

namespace MarcAiAPI.Domain.Entities.Seller
{
    public class SellerEntity
    {
        public long SellerId { get; set; } 
        public long UserId { get; set; } 

        [JsonIgnore]
        public UserEntity? User { get; set; } 

        [JsonIgnore]
        public ICollection<StoreEntity>? Stores { get; set; }
    }
}