using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blogs.Server.Models.HomeViewModels
{
    public class CommentViewModel
    {
        [Display(Name="标题")]
        [Required(ErrorMessage="请输入标题!")]
        public string Title{get;set;}

        [Display(Name="内容")]
        [Required(ErrorMessage="请输入内容!")]
        public string Context{get;set;}

        public Comment GetComment(string userId,string blogId)
        {
            return new Comment
            {
                Context = this.Context,
                UserId = userId,
                BlogId = blogId
            };
        }
    }
}