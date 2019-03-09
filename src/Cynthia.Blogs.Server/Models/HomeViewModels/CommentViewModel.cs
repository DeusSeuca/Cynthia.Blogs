using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cynthia.Blogs.Server.Models.HomeViewModels
{
    public class CommentViewModel
    {
        [Display(Name="评论")]
        [Required(ErrorMessage="需要输入评论内容")]
        public string Context{get;set;}

        //must bind
        [BindRequired]
        public string BlogId{get;set;}

        public Comment GetComment(string userId)
        {
            return new Comment
            {
                Context = this.Context,
                UserId = userId,
                BlogId = this.BlogId
            };
        }
    }
}