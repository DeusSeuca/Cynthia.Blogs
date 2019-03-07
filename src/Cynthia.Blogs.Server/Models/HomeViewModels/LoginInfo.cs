using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blogs.Server.Models.HomeViewModels
{
    public class LoginInfo
    {
        [Display(Name="登陆用户名")]
        [Required(ErrorMessage="请输入登录用户名")]
        public string Username { get; set; }

        [Display(Name="密码")]
        [Required(ErrorMessage="请输入密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}