using Microsoft.AspNetCore.Mvc;
using RK_A6.DB;
using RK_A8.Entities;

namespace RK_A8.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        public TaskController() { }

        [HttpGet("{id}")]
        public ToDoTask Get(int id)
        {
            if (id > ToDoTaskDB.Instance.MaxKey) return null;
            return ToDoTaskDB.Instance.ToDoTasks[id];
        }

        [HttpGet]
        public List<ToDoTask> Get()
        {
            return ToDoTaskDB.Instance.ToDoTasks.Values.ToList();
        }

        [HttpPost]
        public void Post([FromBody] IEnumerable<ToDoTask> tasks)
        {
            foreach (ToDoTask task in tasks)
            {
                ToDoTaskDB.Instance.MaxKey++;
                task.Id = ToDoTaskDB.Instance.MaxKey;
                ToDoTaskDB.Instance.ToDoTasks[ToDoTaskDB.Instance.MaxKey] = task;
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ToDoTask task)
        {
            if (id <= ToDoTaskDB.Instance.MaxKey)
            {
                task.Id = id;
                ToDoTaskDB.Instance.ToDoTasks[id] = task;
            }
        }

        [HttpDelete]
        public void Delete([FromBody] IEnumerable<int> ids)
        {
            foreach (int id in ids)
                ToDoTaskDB.Instance.ToDoTasks.Remove(id);
        }
    }
}