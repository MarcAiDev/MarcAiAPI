using MarcAiAPI.Domain.Entities.Category;

namespace MarcAiAPI.Domain.Entities.Subcategory;

public class SubcategoryEntity
{
    public long SubcategoryId { get; set; }
    public string SubcategoryName { get; set; }
    public string SubcategoryDescription { get; set; }

    public ICollection<CategoryEntity> Categories { get; set; }
}