using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageStaffDB.App.Model;
using Microsoft.EntityFrameworkCore;

namespace ManageStaffDB.App.Model.Data
{
    public class ApplicationContext : DbContext
    {



        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ManageStaffDBAppDB;Trusted_Connection=True;");
        }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
    }
}
