using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using API.Models;

namespace API
{
    public class Startup
    {
        private ApiDbContext db = new ApiDbContext();
        private string JwtSecret = "S3(r3tT051GN_JWT";

        public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
            {
                services.AddCors();
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                services.AddDbContext<ApiDbContext>();

                // configure jwt authentication
                var key = Encoding.ASCII.GetBytes(JwtSecret);
                services.AddAuthentication(x => {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(x => {
                            x.Events = new JwtBearerEvents
                            {
                                OnTokenValidated = context => {
                                    var userId = int.Parse(context.Principal.Identity.Name);
                                    var user = db.Users.Where(u => u.Id == userId).SingleOrDefault();

                                    if (user == null) {
                                        context.Fail("Unauthorized");
                                    }
                                    return Task.CompletedTask;
                                }
                            };
                            x.RequireHttpsMetadata = false;
                            x.SaveToken = true;
                            x.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(key),
                                ValidateIssuer = false,
                                ValidateAudience = false
                            };
                        });

            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment()) {
                    app.UseDeveloperExceptionPage();
                } else {
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseAuthentication();
                app.UseMvc();
                app.UseCors(x => x
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

            }
    }
}
