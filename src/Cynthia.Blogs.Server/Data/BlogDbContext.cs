using Cynthia.Blogs.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cynthia.Blogs.Server.Data
{
    public class BlogDbContext : IdentityDbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User{get;set;}
        public DbSet<Blog> Blog{get;set;}
        public DbSet<Comment> Comment{get;set;}
    }
}