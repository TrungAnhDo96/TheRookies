using Microsoft.AspNetCore.Mvc;
using RK_A9.DTO;
using RK_A9.Interface;

namespace RK_A9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _service;
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddPerson([FromBody] PersonDTO person)
        {
            _service.AddPerson(person);
        }

        [HttpPut("{id}")]
        public void UpdatePerson(int id, [FromBody] PersonDTO person)
        {
            _service.UpdatePerson(id, person);
        }

        [HttpDelete("{id}")]
        public void DeletePerson(int id)
        {
            _service.DeletePerson(id);
        }

        [HttpGet]
        public List<PersonDTO> GetAllPeople()
        {
            return _service.GetAllPeople();
        }

        [HttpGet("filter")]
        public List<PersonDTO> FilterPerson([FromQuery] FilterPersonDTO filterParam)
        {
            return _service.Filter(filterParam);
        }
    }
}