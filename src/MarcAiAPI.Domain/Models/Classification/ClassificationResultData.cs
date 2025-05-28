using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Models.Classification
{
    public class ClassificationResultData
    {
        public List<StoreEntity> SortedStores { get; set; } = new List<StoreEntity>();
    }
}