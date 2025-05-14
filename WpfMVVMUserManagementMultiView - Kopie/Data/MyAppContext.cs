using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMUserManagementMultiView.Model;

namespace WpfMVVMUserManagementMultiView.Data
{
    public class MyAppContext : DbContext
    {
        public DbSet<Person> Persons {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UserMgmt;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
    }
}
