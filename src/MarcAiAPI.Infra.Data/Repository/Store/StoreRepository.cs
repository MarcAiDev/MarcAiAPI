using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Repository.Store
{
    public class StoreRepository : IStoreRepository
    {
        private readonly SqlServerContext _context;

        public StoreRepository(SqlServerContext context)
        {
            _context = context;
        }
        
        public async Task DeleteStore(long storeId)
        {
            _context.Set<StoreEntity>()
                .Remove((await _context.Set<StoreEntity>().FindAsync(storeId))!);
            await _context.SaveChangesAsync();
        }

        public async Task<StoreEntity> GetStore(long storeId)
        {
            return (await _context.Set<StoreEntity>().FindAsync(storeId))!;
        }

        public Task<List<StoreEntity>> GetAllStores()
        {
            return _context.Set<StoreEntity>().ToListAsync();
        }

        public async Task UpdateStore(StoreEntity store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task InsertStore(StoreEntity store)
        {
            await _context.Set<StoreEntity>().AddAsync(store);
            await _context.SaveChangesAsync();
        }
    }
}