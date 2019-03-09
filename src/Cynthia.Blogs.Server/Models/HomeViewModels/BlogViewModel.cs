using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blogs.Server.Models.HomeViewModels
{
    public class BlogViewModel
    {
        [Display(Name="标题")]
        [Required(ErrorMessage="请输入标题!")]
        public string Title{get;set;}

        [Display(Name="内容")]
        [Required(ErrorMessage="请输入内容!")]
        public string Context{get;set;}

        public Blog GetBlog(string userId)
        {
            return new Blog
            {
                Title = this.Title,
                Context = this.Context,
                UserId = userId
            };
        }
    }
}