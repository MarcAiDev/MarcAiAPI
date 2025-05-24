using MarcAiAPI.Domain.Entities.Address;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IStoreAddressRepository
    {
        Task InsertAddress(StoreAddressEntity store);
        Task<StoreAddressEntity?> GetAddress(long storeId);
    }
}