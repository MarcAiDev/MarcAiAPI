using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Category;
using MarcAiAPI.Domain.Entities.Review;
using MarcAiAPI.Domain.Entities.Seller;

namespace MarcAiAPI.Domain.Entities.Store;

public class StoreEntity
{
    public long StoreId { get; set; }
    public string CpfCnpj { get; set; }
    public string StoreName { get; set; }
    public string StoreDescription { get; set; }
    public string OpeningHours { get; set; }
    public bool IsOpen { get; set; }

    public ICollection<ReviewEntity> Reviews { get; set; }
    public SellerEntity Seller { get; set; }
    public ICollection<CategoryEntity> Categories { get; set; }
    public StoreAddressEntity StoreAddress { get; set; }
    public ICollection<StorePhoto> Photos { get; set; }
}