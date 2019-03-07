using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blogs.Server.Models.HomeViewModels
{
    public class RegisterInfo
    {
        //Necessary information for registered users
        [Display(Name="登陆名称")]
        [Required(ErrorMessage="请输入登录用户名")]
        [Range(4,30,ErrorMessage="不合要求，至少2个字符，最多30个字符")]
        public string Username { get; set; }

        [Display(Name="密码")]
        [Required(ErrorMessage="请输入密码")]
        [Range(8,30,ErrorMessage="不合要求，至少2个字符，最多20个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="确认密码")]
        [Compare("Password",ErrorMessage="确认密码错误")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Display(Name="显示名称")]
        [Range(2,20,ErrorMessage="不合要求，至少2个字符，最多20个字符")]
        [Required(ErrorMessage="请输入显示名称")]
        public string ShowName { get; set; }

        public ApplicationUser GetUser()
        {
            return new ApplicationUser()
            {
                UserName = this.Username,
                ShowName = this.ShowName
            };
        }
    }
}