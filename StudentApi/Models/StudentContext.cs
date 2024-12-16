using Microsoft.EntityFrameworkCore;

namespace StudentApi.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null;

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }
    }
}
