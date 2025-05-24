using MarcAiAPI.Domain.DTOs;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Repository.Store
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<StoreEntity>> GetStore(long? storeId, long? marketplaceId, long? sellerId)
        {
            return await _context.Store
                .Where(s =>
                    (!storeId.HasValue || s.StoreId == storeId.Value) &&
                    (!marketplaceId.HasValue || s.MarketplaceId == marketplaceId.Value) &&
                    (!sellerId.HasValue || s.SellerId == sellerId.Value)
                )
                .ToListAsync();
        }


        
        public async Task DeleteStore(long storeId)
        {
            _context.Set<StoreEntity>()
                .Remove((await _context.Set<StoreEntity>().FindAsync(storeId))!);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateStore(StoreEntity store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task InsertStore(CreateStoreRequest createStoreRequest)
        {
            _context.Store.Add(createStoreRequest.Store);

            createStoreRequest.Address.StoreId = createStoreRequest.Store.StoreId;

            _context.StoreAddress.Add(createStoreRequest.Address);
            await _context.SaveChangesAsync();
        }

    }
}