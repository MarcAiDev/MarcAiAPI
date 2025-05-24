using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Interfaces.Marketplace
{
    public interface IMarketplaceService
    {
        Task<IEnumerable<MarketplaceEntity>> GetMarketplacesAsync(long? id, string? name);
    }
}