using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Cynthia.Blogs.Server.Models;
using Cynthia.Blogs.Server.Models.HomeViewModels;
using Microsoft.AspNetCore.Identity;

namespace Cynthia.Blogs.Server.Services
{
    public class Business : IBusiness
    {
        private BlogDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public Business(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, BlogDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> Login(LoginInfo info)
        {
            var user = await _userManager.FindByNameAsync(info.LoginName);
            if (user == null) return false;
            var result = await _signInManager.PasswordSignInAsync(user, info.Password, false, false);
            return result.Succeeded;
        }

        public async Task<bool> Register(RegisterInfo info)
        {
            var user = info.GetUser();
            return (await _userManager.CreateAsync(user,info.Password)).Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}