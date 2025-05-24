using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Infra.Data.Context;

namespace MarcAiAPI.Infra.Data.Repository.Store
{
    public class StoreAddressRepository : IStoreAddressRepository
    {
        private readonly AppDbContext _context;

        public StoreAddressRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task InsertAddress(StoreAddressEntity adress)
        {
            await _context.Set<StoreAddressEntity>().AddAsync(adress);
            await _context.SaveChangesAsync();
        }

        public async Task<StoreAddressEntity?> GetAddress(long storeId)
        {
            return await _context.Set<StoreAddressEntity>().FindAsync(storeId);
        }
    }
}