using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _service;

        public StoreController(IStoreService service)
        {
            _service = service;
        }

        [HttpGet("store")]
        public async Task<IActionResult> GetStore([FromQuery]long? id, long? marketplaceId, long? sellerId)
        {
            var result = await _service.GetStoreAsync(id, marketplaceId, sellerId);
            return Ok(result);
        }

        [HttpGet("address")]
        public async Task<IActionResult> GetAddress([FromQuery] long storeId)
        {
            var result = await _service.GetAddressAsync(storeId);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStore(CreateStoreRequest createStoreRequest)
        {
            await _service.CreateStoreAsync(createStoreRequest);
            return Ok("Loja inserida com sucesso.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStore(StoreEntity store)
        {
            await _service.UpdateStoreAsync(store);
            return Ok("Loja atualizada com sucesso.");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteStore(long id)
        {
            await _service.DeleteStoreAsync(id);
            return Ok("Loja excluida com sucesso.");
        }
    }
}