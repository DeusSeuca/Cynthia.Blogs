using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Cynthia.Blogs.Server.Models.HomeViewModels;
using Cynthia.Blogs.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController:Controller
{
    private readonly BlogDbContext _context;
    private readonly IBusiness _business;
    public HomeController(BlogDbContext context,IBusiness business)
    {
        _context = context;
        _business = business;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult EditPost()
    {
        return View();
    }

    public async Task<IActionResult> UserList()
    {
        var users = await _context.User.ToListAsync();
        return View(users);
    }

    public IActionResult TheUser(string id)
    {
        var user = _context.User.SingleOrDefault(x=>x.Id==id);
        if(user != null)
            return View(user);
        return View("Error");
    }
}