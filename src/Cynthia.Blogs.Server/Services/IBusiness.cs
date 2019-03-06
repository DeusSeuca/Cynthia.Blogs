using System.Threading.Tasks;
using Cynthia.Blogs.Server.Models.ViewModels;

namespace Cynthia.Blogs.Server.Services
{
    //business logic service
    public interface IBusiness
    {
        Task<UserInfo> Login(string username,string password);
        Task<bool> Register(RegisterInfo info);
    }
}