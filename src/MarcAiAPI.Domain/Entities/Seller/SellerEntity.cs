using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Entities.Seller;

public class SellerEntity
{
    public long SellerId { get; set; }
    public long PersonId { get; set; }
    public bool IsVerified { get; set; }

    public PersonEntity Person { get; set; }
    public ICollection<StoreEntity> Stores { get; set; }
}