using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using API.Models;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
            {

                using (var db = new ApiDbContext())
                {
                    db.Movies.Add(new Movies { Name = "HEY HEY HEY" });
                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);

                    Console.WriteLine();
                    Console.WriteLine("All blogs in database:");
                    foreach (var movie in db.Movies)
                    {
                        Console.WriteLine(" - {0}", movie.Name);
                    }
                }

                CreateWebHostBuilder(args).Build().Run();
            }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
