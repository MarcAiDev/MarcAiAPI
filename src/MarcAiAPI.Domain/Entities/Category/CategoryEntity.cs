using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Entities.Subcategory;

namespace MarcAiAPI.Domain.Entities.Category;

public class CategoryEntity
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }

    public ICollection<SubcategoryEntity>? Subcategories { get; set; } = new List<SubcategoryEntity>();
    public ICollection<StoreEntity>? Stores { get; set; } = new List<StoreEntity>();
}