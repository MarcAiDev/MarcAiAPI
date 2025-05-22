using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IStoreRepository
    {
        Task DeleteStore(long storeId);
        Task<StoreEntity> GetStore(long storeId);
        Task<List<StoreEntity>> GetAllStores();
        Task UpdateStore (StoreEntity store);
        Task InsertStore (StoreEntity store);
    }
}