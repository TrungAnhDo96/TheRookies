using RK_A8.DB;
using RK_A8.DTO;
using RK_A8.Entities;
using RK_A8.Interface;
using RK_A8.Utilities;

namespace RK_A8.Services
{
    public class WorkTaskService : IWorkTaskService
    {
        private TaskContext _context;

        public WorkTaskService(TaskContext context)
        {
            _context = context;
        }

        public void AddTask(DTOTask task)
        {
            _context.Tasks.Add(new WorkTask() { Title = task.Title, IsCompleted = task.IsCompleted });
            _context.SaveChanges();
        }

        public void AddTasks(List<DTOTask> tasks)
        {
            var addingTasks = tasks.Select(task => task.DTOToEntity());
            _context.Tasks.AddRange(addingTasks);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            WorkTask foundTask = _context.Tasks.Find(id);
            if (foundTask != null)
            {
                _context.Tasks.Remove(foundTask);
                _context.SaveChanges();
            }
        }

        public void DeleteTasks(List<int> ids)
        {
            var foundTasks = _context.Tasks.Where(task => ids.Contains(task.Id));
            if (foundTasks.Any())
            {
                _context.Tasks.RemoveRange(foundTasks);
                _context.SaveChanges();
            }
        }

        public List<DTOTask> GetAllTasks()
        {
            List<DTOTask> result = _context.Tasks.Select(task => task.EntityToDTO()).ToList();
            return result;
        }

        public DTOTask GetTask(int id)
        {
            WorkTask foundTask = _context.Tasks.Find(id);
            DTOTask result = new DTOTask() { Title = "Not found", IsCompleted = false };
            if (foundTask != null)
                result = foundTask.EntityToDTO();
            return result;
        }

        public void UpdateTask(int id, DTOTask task)
        {
            WorkTask taskToUpdate = _context.Tasks.Find(id);
            if (taskToUpdate != null)
            {
                taskToUpdate.Title = task.Title;
                taskToUpdate.IsCompleted = task.IsCompleted;
                _context.Tasks.Update(taskToUpdate);
                _context.SaveChanges();
            }
        }
    }
}