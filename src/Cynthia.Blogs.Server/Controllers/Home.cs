using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController:Controller
{
    private readonly BlogDbContext _context;
    public HomeController(BlogDbContext context) => _context = context;
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public async Task<IActionResult> UserList()
    {
        var users = await _context.User.ToListAsync();
        return View(users);
    }

    public IActionResult TheUser(int id)
    {
        var user = _context.User.SingleOrDefault(x=>x.Id==id);
        if(user != null)
            return View(user);
        return View("Error");
    }
}