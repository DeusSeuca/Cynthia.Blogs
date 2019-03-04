using Cynthia.Blogs.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Cynthia.Blogs.Server.Data
{
    public class BlogDbContext:DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<Blog> Blogs{get;set;}
        public DbSet<Comment> Comments{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //local datebase slqite, It can be replaced by other specific databases according to actual needs.
            //optionsBuilder.UseMySql("Server=132.232.106.125,3306;database=Blog;uid=xxx;pwd=xxx;");
            optionsBuilder.UseSqlite("Data Source=Blog.db");
        }
    }
}