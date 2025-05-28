using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Models;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IStoreRepository
    {
        Task DeleteStore(long storeId);
        Task<List<StoreEntity>> GetStore(long? storeId, long? marketplaceId, long? sellerId);
        Task UpdateStore (StoreEntity store);
        Task InsertStore (CreateStoreRequest createStoreRequest);
    }
}