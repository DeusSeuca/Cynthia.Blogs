using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Cynthia.Blogs.Server.Models;
using Cynthia.Blogs.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace Cynthia.Blogs.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //database connection string config
            services.AddDbContext<BlogDbContext>(options=>{
                options.UseSqlite(_configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IBusiness,Business>();
            services.AddMvc();
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<BlogDbContext>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // context.User.Add(new User(){LoginName="Cynthia",UserName="辛西娅",Password="cc123456"});
            // context.User.Add(new User(){LoginName="RedGezi",UserName="格子",Password="gezi654321"});
            //context.SaveChanges();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath,"node_modules"))
            });
            app.UseAuthentication();
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
