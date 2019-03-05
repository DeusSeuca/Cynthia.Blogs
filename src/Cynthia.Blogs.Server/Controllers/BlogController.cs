using Cynthia.Blogs.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cynthia.Blogs.Server.Controllers
{
    public class BlogController:Controller
    {
        private readonly BlogDbContext _dbcontext;
        public BlogController(BlogDbContext context) => _dbcontext = context;
    }
}