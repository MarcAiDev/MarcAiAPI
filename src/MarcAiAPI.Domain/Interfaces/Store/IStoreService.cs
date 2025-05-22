using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IStoreService
    {
        Task InsertStoreAsync(StoreEntity store);
        Task UpdateStoreAsync(StoreEntity store);
        Task DeleteStoreAsync(long storeId);
        Task<StoreEntity> GetStoreAsync(long storeId);
        Task<List<StoreEntity>> GetAllStoresAsync();
    }
}