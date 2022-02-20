using Microsoft.AspNetCore.Mvc;
using RK_A8.DTO;
using RK_A8.Interface;

namespace RK_A8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private IToDoTaskService _service;

        public TaskController(IToDoTaskService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public DTOTask Get(int id)
        {
            return _service.GetTask(id);
        }

        [HttpGet]
        public List<DTOTask> Get()
        {
            return _service.GetAllTasks();
        }

        [HttpPost]
        public void Post([FromBody] DTOTask task)
        {
            _service.AddTask(task);
        }

        [HttpPost("/AddTasks")]
        public void AddTasks([FromBody] List<DTOTask> tasks)
        {
            _service.AddTasks(tasks);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DTOTask task)
        {
            _service.UpdateTask(id, task);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteTask(id);
        }

        [HttpDelete]
        public void Delete([FromBody] List<int> ids)
        {
            _service.DeleteTasks(ids);
        }
    }
}