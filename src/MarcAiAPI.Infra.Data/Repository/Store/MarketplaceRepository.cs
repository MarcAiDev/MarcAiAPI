using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Marketplace;
using MarcAiAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Repository.Store
{
    public class MarketplaceRepository : IMarketplaceRepository
    {
        private readonly AppDbContext _context;

        public MarketplaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MarketplaceEntity>> GetMarketplace(long? id, string? name)
        {
            return await _context.Marketplace
                .Where(m => !id.HasValue || m.MarketplaceId == id.Value)
                .Where(m => string.IsNullOrWhiteSpace(name) || EF.Functions.Like(m.Name, $"%{name}%"))
                .ToListAsync();
        }
    }
}