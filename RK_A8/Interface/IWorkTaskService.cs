using RK_A8.DTO;

namespace RK_A8.Interface
{
    public interface IWorkTaskService
    {
        void AddTask(WorkTaskDTO task);

        List<WorkTaskDTO> GetAllTasks();

        WorkTaskDTO GetTask(int id);

        void UpdateTask(int id, WorkTaskDTO task);

        void DeleteTask(int id);

        void DeleteTasks(List<int> ids);

        void AddTasks(List<WorkTaskDTO> tasks);
    }
}