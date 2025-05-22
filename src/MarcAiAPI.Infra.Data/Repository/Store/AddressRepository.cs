using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Repository.Store
{
    public class AddressRepository : IAddressRepository
    {
        private readonly SqlServerContext _context;

        public AddressRepository(SqlServerContext context)
        {
            _context = context;
        }
        
        public async Task DeleteStoreAddress(long storeId)
        {
            _context.Set<StoreAddressEntity>()
                .Remove((await _context.Set<StoreAddressEntity>().FindAsync(storeId))!);
            await _context.SaveChangesAsync();
        }

        public async Task<StoreAddressEntity> GetStoreAddress(long storeId)
        {
            return (await _context.Set<StoreAddressEntity>().FindAsync(storeId))!;
        }

        public Task<List<StoreAddressEntity>> GetAllStoresAddress()
        {
            return _context.Set<StoreAddressEntity>().ToListAsync();
        }

        public async Task UpdateStoreAddress(StoreAddressEntity store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task InsertStoreAddress(StoreAddressEntity store)
        {
            await _context.Set<StoreAddressEntity>().AddAsync(store);
            await _context.SaveChangesAsync();
        }
    }
}