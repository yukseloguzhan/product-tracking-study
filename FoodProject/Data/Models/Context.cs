using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Data.Models
{
    public class Context  : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FoodDB");  // database ismi degistirerblirsin

        }

        public DbSet<Food> Foods { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Admin>  Admins { set; get; }

    }
}
