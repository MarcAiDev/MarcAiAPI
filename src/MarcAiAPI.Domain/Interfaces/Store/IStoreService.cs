using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Models;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IStoreService
    {
        Task<List<StoreEntity>> GetStoreAsync(long? storeId, long? marketplaceId, long? sellerId);
        Task<StoreAddressEntity> GetAddressAsync(long storeId);
        Task CreateStoreAsync(CreateStoreRequest createStoreRequest);
        Task UpdateStoreAsync(StoreEntity store);
        Task DeleteStoreAsync(long storeId);
    }
}