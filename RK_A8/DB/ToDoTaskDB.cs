using RK_A8.Entities;

namespace RK_A6.DB
{
    public class ToDoTaskDB
    {
        // Singleton
        private static ToDoTaskDB _instance;
        public static ToDoTaskDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ToDoTaskDB();
                }
                return _instance;
            }
        }

        private Dictionary<int, ToDoTask> _tasks;
        public ToDoTaskDB()
        {
            Initialize();
        }

        private void Initialize()
        {
            _tasks = new Dictionary<int, ToDoTask>() {
                {1, new ToDoTask(1, "Eat")},
                {2, new ToDoTask(2, "Sleep")},
                {3, new ToDoTask(3, "Code")},
                {4, new ToDoTask(4, "Repeat")}
            };
            MaxKey = _tasks.Keys.Max();
        }

        public Dictionary<int, ToDoTask> ToDoTasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
            }
        }

        public int MaxKey { get; set; }
    }
}