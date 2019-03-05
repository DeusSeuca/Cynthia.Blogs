using Cynthia.Blogs.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cynthia.Blogs.Server.Data
{
    public class BlogDbContext : IdentityDbContext
    {
        public DbSet<User> User{get;set;}
        public DbSet<Blog> Blog{get;set;}
        public DbSet<Comment> Comment{get;set;}

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
        // private string _connectionString;

        // public BlogDbContext(IConfiguration configuration)
        // {
        //     _connectionString = configuration["SqlConnectionString"];
        // }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     //local datebase slqite, It can be replaced by other specific databases according to actual needs.
        //     //optionsBuilder.UseMySql("Server=132.232.106.125,3306;database=Blog;uid=xxx;pwd=xxx;");
        //     optionsBuilder.UseSqlite(_connectionString);
        // }
    }
}