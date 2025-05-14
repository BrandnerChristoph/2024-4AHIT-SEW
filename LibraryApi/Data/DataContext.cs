using LibraryApi.Model;
using LibraryApi.Model.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    
    public class PersonalDataContext : IdentityDbContext<PersonalUser>
    {
        public DbSet<Book> Books { get; set; }
        public PersonalDataContext(DbContextOptions<PersonalDataContext> options) : base(options) { }
    }
    
}
