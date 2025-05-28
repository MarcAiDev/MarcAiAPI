using System.Text.Json.Serialization;
using MarcAiAPI.Domain.Entities.Seller;

namespace MarcAiAPI.Domain.Entities.User
{
    public class UserEntity
         {
             public long UserId { get; set; }
             public string Name { get; set; }
             public string Cpf { get; set; }
             public string Email { get; set; }
             public string? Photo { get; set; }
             public string PhoneNumber { get; set; }
             public DateTime DateOfBirth { get; set; }
             public  string Password { get; set; }
         
             [JsonIgnore]
             public SellerEntity? SellerProfile { get; set; }
         }
}