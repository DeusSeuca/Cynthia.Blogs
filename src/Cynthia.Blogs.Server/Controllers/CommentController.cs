using Cynthia.Blogs.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cynthia.Blogs.Server.Controllers
{
    public class CommentController:Controller
    {
        private readonly BlogDbContext _dbcontext;
        public CommentController(BlogDbContext context) => _dbcontext = context;
    }
}