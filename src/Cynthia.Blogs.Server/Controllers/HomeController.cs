using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Cynthia.Blogs.Server.Models;
using Cynthia.Blogs.Server.Models.HomeViewModels;
using Cynthia.Blogs.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly BlogDbContext _context;
    private readonly IBusiness _business;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    public HomeController(BlogDbContext context, IBusiness business, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _business = business;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var bloglist = new BlogListViewModel()
        {
            Blogs = _context.Blog.AsEnumerable()
            .Select(x=>new BlogListItemViewModel(x,_context))
            .OrderBy(x=>x.ReleaseTime)
        };
        return View(bloglist);
    }

    //must login
    [HttpGet]
    [Authorize]
    public IActionResult EditPost()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPost(BlogViewModel info)
    {
        if (!ModelState.IsValid)
            return View(info);
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var blog = (await _context.Blog.AddAsync(info.GetBlog(user.Id))).Entity;
        await _context.SaveChangesAsync();
        //show blog
        return RedirectToAction(nameof(BlogShow),"Home",new{id=blog.Id});
    }

    public IActionResult BlogShow(string id)
    {
        //if not find
        var blog = _context.Blog.SingleOrDefault(x=>x.Id==id);
        if(blog==null)
        {
            return RedirectToAction(nameof(Index));
        }
        //show blog
        return View(new BlogShowViewModel(blog,_context));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Comment(CommentViewModel comment)
    {
        var c = comment.GetComment((await _userManager.GetUserAsync(HttpContext.User)).Id);
        await _context.Comment.AddAsync(c);
        await _context.SaveChangesAsync();
        //return to blog
        return RedirectToAction(nameof(BlogShow),"Home",new{id=comment.BlogId});
    }

    public async Task<IActionResult> UserList()
    {
        var users = await _context.User.ToListAsync();
        return View(users);
    }

    public IActionResult TheUser(string id)
    {
        var user = _context.User.SingleOrDefault(x => x.Id == id);
        if (user != null)
            return View(user);
        return View("Error");
    }
}