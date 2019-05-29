using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ApiDbContext : DbContext
    {
        // public ApiDbContext(DbContextOptions options) : base(options)
        //     {
        //     }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=net5.db");
            }
    }
}
