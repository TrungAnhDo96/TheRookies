using Microsoft.EntityFrameworkCore;
using RK_A10.Entities;

namespace RK_A10.DB
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}