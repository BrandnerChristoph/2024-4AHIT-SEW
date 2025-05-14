using Microsoft.EntityFrameworkCore;

namespace ProspectRegistration.Models
{
    public class ProspectDbContext : DbContext
    {
        public DbSet<Prospect> Prospects { get; set; }
        public ProspectDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
