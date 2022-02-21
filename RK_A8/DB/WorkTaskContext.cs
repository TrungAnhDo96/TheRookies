using Microsoft.EntityFrameworkCore;
using RK_A8.Entities;

namespace RK_A8.DB
{
    public class WorkTaskContext : DbContext
    {
        public WorkTaskContext(DbContextOptions<WorkTaskContext> options) : base(options) { }

        public DbSet<WorkTask> Tasks { get; set; }
    }
}