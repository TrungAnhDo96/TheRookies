namespace RK_A8.Entities
{
    public class ToDoTask
    {
        public ToDoTask(int id, string title, bool isCompleted = false)
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}