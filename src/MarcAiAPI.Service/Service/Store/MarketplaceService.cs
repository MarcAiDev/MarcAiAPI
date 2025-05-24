using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Marketplace;

namespace MarcAiAPI.Service.Service.Store
{
    public class MarketplaceService : IMarketplaceService
    {
        private readonly IMarketplaceRepository _marketplaceRepository;

        public MarketplaceService(IMarketplaceRepository marketplaceRepository)
        {
            _marketplaceRepository = marketplaceRepository;
        }

        public async Task<IEnumerable<MarketplaceEntity>> GetMarketplacesAsync(long? id, string? name)
        {
            return await _marketplaceRepository.GetMarketplace(id, name);
        }
    }
}