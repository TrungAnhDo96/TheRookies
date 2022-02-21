using Microsoft.AspNetCore.Mvc;
using RK_A8.DTO;
using RK_A8.Interface;

namespace RK_A8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private IWorkTaskService _service;

        public TaskController(IWorkTaskService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public WorkTaskDTO Get(int id)
        {
            return _service.GetTask(id);
        }

        [HttpGet]
        public List<WorkTaskDTO> Get()
        {
            return _service.GetAllTasks();
        }

        [HttpPost]
        public void Post([FromBody] WorkTaskDTO task)
        {
            _service.AddTask(task);
        }

        [HttpPost("/AddTasks")]
        public void AddTasks([FromBody] List<WorkTaskDTO> tasks)
        {
            _service.AddTasks(tasks);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WorkTaskDTO task)
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