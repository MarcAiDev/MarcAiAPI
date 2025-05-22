using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Store;
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

        [HttpGet("GetAllStores")]
        public IActionResult GetAllStores()
        {
            var result = _service.GetAllStoresAsync();
            return Ok(result);
        }

        [HttpGet("GetStoreById/{id}")]
        public IActionResult GetStoreById([FromQuery]long id)
        {
            var result = _service.GetStoreAsync(id);
            return Ok(result);
        }

        [HttpPost("CreateStore")]
        public IActionResult CreateStore([FromBody] StoreEntity store)
        {
            var result = _service.InsertStoreAsync(store);
            return Ok(result);
        }

        [HttpPut("UpdateStore")]
        public IActionResult UpdateStore([FromBody] StoreEntity store)
        {
            var result = _service.UpdateStoreAsync(store);
            return Ok(result);
        }

        [HttpDelete("DeleteStore/{id}")]
        public IActionResult DeleteStore([FromQuery]long id)
        {
            var result = _service.DeleteStoreAsync(id);
            return Ok(result);
        }
    }
}