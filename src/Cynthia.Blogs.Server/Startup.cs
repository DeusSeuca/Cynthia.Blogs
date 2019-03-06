using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Cynthia.Blogs.Server.Models;
using Cynthia.Blogs.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cynthia.Blogs.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //database connection string config
            services.AddDbContext<BlogDbContext>(options=>{
                options.UseSqlite(Configuration.GetConnectionString("Default"));
            });
            services.AddSingleton<IBusiness,Business>();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration,ILogger<Startup> logger,BlogDbContext context)
        {
            // context.User.Add(new User(){LoginName="Cynthia",UserName="辛西娅",Password="cc123456"});
            // context.User.Add(new User(){LoginName="RedGezi",UserName="格子",Password="gezi654321"});
            context.SaveChanges();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default", 
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
