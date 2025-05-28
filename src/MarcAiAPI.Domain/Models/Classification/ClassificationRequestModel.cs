using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Models.Classification
{
    public class ClassificationRequestModel
    {
        public List<string> Preferences { get; set; } = new List<string>();
        public List<StoreEntity> Stores { get; set; } = new List<StoreEntity>();
    }
}