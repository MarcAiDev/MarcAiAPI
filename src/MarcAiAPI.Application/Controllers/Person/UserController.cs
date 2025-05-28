using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Interfaces.Person;
using MarcAiAPI.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUser([FromQuery] long? id) 
        {
            var result = await _service.GetUserAsync(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestAddModel user)
        {
            await _service.InsertUserAsync(user);
            return Ok("Usuario inserido com sucesso.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePerson([FromBody] UserResquestUpdateModel user)
        {
            await _service.UpdateUserAsync(user);
            return Ok("Usuario atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromQuery]long id)
        {
            await _service.DeleteUserAsync(id);
            return Ok("Usuario removido com sucesso.");
        }
    }
}