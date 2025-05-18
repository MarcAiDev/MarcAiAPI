using MarcAiAPI.Domain.Entities.Review;
using MarcAiAPI.Domain.Entities.Seller;

namespace MarcAiAPI.Domain.Entities.Person;

public class PersonEntity
{
    public long PersonId { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; }
    public bool IsSeller { get; set; }

    public ICollection<ReviewEntity> Reviews { get; set; }
    public SellerEntity Seller { get; set; }
}