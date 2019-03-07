using System.Threading.Tasks;
using Cynthia.Blogs.Server.Models.HomeViewModels;

namespace Cynthia.Blogs.Server.Services
{
    //business logic service
    public interface IBusiness
    {
        Task<bool> Login(LoginInfo info);
        Task Logout();
        Task<bool> Register(RegisterInfo info);
    }
}