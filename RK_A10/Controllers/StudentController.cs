using Microsoft.AspNetCore.Mvc;
using RK_A10.DTO;
using RK_A10.Interface;

namespace RK_A10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddStudent([FromBody] StudentDTO student)
        {
            await _service.AddStudent(student);
        }

        [HttpGet("{id}")]
        public async Task<StudentDTO> GetStudent(int id)
        {
            return await _service.GetStudent(id);
        }

        [HttpGet("all")]
        public async Task<List<StudentDTO>> GetAllStudents()
        {
            return await _service.GetAllStudents();
        }

        [HttpPut("{id}")]
        public async Task UpdateStudent(int id, [FromBody] StudentDTO student)
        {
            await _service.UpdateStudent(id, student);
        }

        [HttpDelete]
        public async Task DeleteStudent(int id)
        {
            await _service.DeleteStudent(id);
        }
    }
}