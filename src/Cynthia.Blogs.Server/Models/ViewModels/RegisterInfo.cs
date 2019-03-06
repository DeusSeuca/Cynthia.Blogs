namespace Cynthia.Blogs.Server.Models.ViewModels
{
    public class RegisterInfo
    {
        //Necessary information for registered users
        public RegisterInfo(string loginName,string password,string username)
        {
            LoginName = loginName;
            Password = password;
            UserName = username;
        }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public User GetUser()
        {
            return new User()
            {
                LoginName = this.LoginName,
                Password = this.Password,
                UserName = this.UserName
            };
        }
    }
}