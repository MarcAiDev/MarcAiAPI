using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Interfaces.Person;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet("GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            var result = _service.GetAllPersonsAsync();
            return Ok(result);
        }

        [HttpGet("GetPersonById/{id}")]
        public IActionResult GetPersonById([FromQuery]long id)
        {
            var result = _service.GetPersonAsync(id);
            return Ok(result);
        }

        [HttpPost("CreatePerson")]
        public IActionResult CreatePerson([FromBody] PersonEntity person)
        {
            var result = _service.InsertPersonAsync(person);
            return Ok(result);
        }

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] PersonEntity person)
        {
            var result = _service.UpdatePersonAsync(person);
            return Ok(result);
        }

        [HttpDelete("DeletePerson/{id}")]
        public IActionResult DeletePerson([FromQuery]long id)
        {
            var result = _service.DeletePersonAsync(id);
            return Ok(result);
        }
    }
}