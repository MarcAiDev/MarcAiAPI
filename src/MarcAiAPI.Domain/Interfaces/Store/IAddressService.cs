using MarcAiAPI.Domain.Entities.Address;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IAddressService
    {
        Task InsertStoreAddressAsync(StoreAddressEntity address);
        Task UpdateStoreAddressAsync(StoreAddressEntity address);
        Task DeleteStoreAddressAsync(long storeId);
        Task<StoreAddressEntity> GetStoreAddressAsync(long storeId);
        Task<List<StoreAddressEntity>> GetAllStoresAddressAsync();
    }
}