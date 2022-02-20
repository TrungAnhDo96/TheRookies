using RK_A8.DTO;

namespace RK_A8.Interface
{
    public interface IToDoTaskService
    {
        void AddTask(DTOTask task);

        List<DTOTask> GetAllTasks();

        DTOTask GetTask(int id);

        void UpdateTask(int id, DTOTask task);

        void DeleteTask(int id);

        void DeleteTasks(List<int> ids);

        void AddTasks(List<DTOTask> tasks);
    }
}