using Microsoft.EntityFrameworkCore;
using OstereiVerwaltungMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstereiVerwaltungMVVM.Data
{
    class OstereiContext : DbContext
    {
        public DbSet<Osterei> Ostereier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OsterDb;Trusted_Connection=True;");
        }

    }
}
