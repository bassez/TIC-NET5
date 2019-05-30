using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //     optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;Pooling=False");
                optionsBuilder.UseSqlite("Data Source=net5.db");
            }
    }
}
