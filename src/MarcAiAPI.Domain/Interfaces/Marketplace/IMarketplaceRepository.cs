using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Interfaces.Marketplace
{
    public interface IMarketplaceRepository
    {
        Task<IEnumerable<MarketplaceEntity>> GetMarketplace(long? id, string? name);
    }
}