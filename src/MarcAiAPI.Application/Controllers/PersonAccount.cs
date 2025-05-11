using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Interfaces;
using MarcAiAPI.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonAccount(IBaseService<PersonEntity> service) : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody] PersonEntity person)
        {
            return Execute(() => service.Add<PersonAccountValidator>(person).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonEntity person)
        {
            return Execute(() => service.Update<PersonAccountValidator>(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            Execute(() =>
            {
                service.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return id == 0 ? NotFound() : Execute(() => service.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}