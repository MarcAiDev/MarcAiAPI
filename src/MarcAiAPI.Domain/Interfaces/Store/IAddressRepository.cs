using MarcAiAPI.Domain.Entities.Address;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IAddressRepository
    {
        Task DeleteStoreAddress(long storeId);
        Task<StoreAddressEntity> GetStoreAddress(long storeId);
        Task<List<StoreAddressEntity>> GetAllStoresAddress();
        Task UpdateStoreAddress (StoreAddressEntity store);
        Task InsertStoreAddress (StoreAddressEntity store);
    }
}