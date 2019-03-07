using Cynthia.Blogs.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cynthia.Blogs.Server.Data
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> User{get;set;}
        public DbSet<Blog> Blog{get;set;}
        public DbSet<Comment> Comment{get;set;}
    }
}