using System.Text.Json.Serialization;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Entities.User
{
    public class UserEntity
    {
        public long UserId { get; set; }
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public string? Email { get; set; }
        public string? Photo { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Password { get; set; }
    
        public long? SellerId { get; set; }
    
        [JsonIgnore]
        public ICollection<StoreEntity>? Stores { get; set; }
    }
}