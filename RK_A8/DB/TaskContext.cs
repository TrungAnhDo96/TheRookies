using Microsoft.EntityFrameworkCore;
using RK_A8.Entities;

namespace RK_A8.DB
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<WorkTask> Tasks { get; set; }
    }
}