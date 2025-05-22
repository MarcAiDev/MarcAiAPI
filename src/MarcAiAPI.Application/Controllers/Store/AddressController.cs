using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Interfaces.Store;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet("GetAllStoresAddress")]
        public IActionResult GetAllStoresAddress()
        {
            var result = _service.GetAllStoresAddressAsync();
            return Ok(result);
        }

        [HttpGet("GetStoreAddressById/{id}")]
        public IActionResult GetStoreAddressById([FromQuery]long id)
        {
            var result = _service.GetStoreAddressAsync(id);
            return Ok(result);
        }

        [HttpPost("CreateStoreAddress")]
        public IActionResult CreateStoreAddress([FromBody] StoreAddressEntity address)
        {
            var result = _service.InsertStoreAddressAsync(address);
            return Ok(result);
        }

        [HttpPut("UpdateStoreAddress")]
        public IActionResult UpdateStoreAddress([FromBody] StoreAddressEntity address)
        {
            var result = _service.UpdateStoreAddressAsync(address);
            return Ok(result);
        }

        [HttpDelete("DeleteStoreAddress/{id}")]
        public IActionResult DeleteStoreAddress([FromQuery]long id)
        {
            var result = _service.DeleteStoreAddressAsync(id);
            return Ok(result);
        }
    }
}