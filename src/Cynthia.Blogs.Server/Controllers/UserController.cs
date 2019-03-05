using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cynthia.Blogs.Server.Controllers
{
    public class UserController:Controller
    {
        private readonly BlogDbContext _dbcontext;
        public UserController(BlogDbContext context) => _dbcontext = context;

        public async Task<ActionResult> Test()
        {
            await Task.CompletedTask;
            return View(new{Time=DateTimeOffset.Now});
        }
    }
}