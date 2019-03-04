using Microsoft.EntityFrameworkCore;

namespace Cynthia.Blog.Server
{
    public class BlogDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //slqite, It can be replaced by other specific databases according to actual needs.
            //optionsBuilder.UseMySql("Server=132.232.106.125,3306;database=Blog;uid=xxx;pwd=xxx;");
            optionsBuilder.UseSqlite("Data Source=Blog.db");
        }
    }
}