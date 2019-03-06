using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Data;
using Cynthia.Blogs.Server.Models.ViewModels;

namespace Cynthia.Blogs.Server.Services
{
    public class Business : IBusiness
    {
        private BlogDbContext _context;
        public Business(BlogDbContext context) => _context = context;

        public async Task<UserInfo> Login(string loginName, string password)
        {
            await Task.CompletedTask;
            if(!_context.User.Any(x=>x.UserName==loginName&&x.Password==password))
                return null;

            var user = _context.User.Single(x=>x.UserName==loginName&&x.Password==password);
            return new UserInfo($"Hello {user.UserName}");
        }

        public async Task<bool> Register(RegisterInfo info)
        {
            if(_context.User.Any(x=>x.LoginName==info.LoginName))
                return false;

            await _context.User.AddAsync(info.GetUser());
            return true;
        }
    }
}