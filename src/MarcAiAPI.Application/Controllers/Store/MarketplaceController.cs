using MarcAiAPI.Domain.Interfaces.Marketplace;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketplaceController : ControllerBase
    {
        private readonly IMarketplaceService _service;

        public MarketplaceController(IMarketplaceService service)
        {
            _service = service;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMarketplaces([FromQuery] long? id, string? name)
        {
            var result = await _service.GetMarketplacesAsync(id, name);
            return Ok(result);
        }
    }
}