namespace Cynthia.Blogs.Server.Models.ViewModels
{
    //Information acquired by users after login
    public class UserInfo
    {
        public string TestMessage{get;}
        public UserInfo(string testMessage)
        {
            TestMessage = testMessage;
        }
    }
}