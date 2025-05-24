using MarcAiAPI.Domain.DTOs;
using MarcAiAPI.Domain.Entities.Store;

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