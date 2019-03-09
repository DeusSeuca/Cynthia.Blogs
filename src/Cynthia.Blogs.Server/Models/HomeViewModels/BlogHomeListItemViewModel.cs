using System;
using System.Linq;
using Cynthia.Blogs.Server.Data;

namespace Cynthia.Blogs.Server.Models.HomeViewModels
{
    public class BlogListItemViewModel
    {
        public BlogListItemViewModel(Blog blog,BlogDbContext context)
        {
            Title = blog.Title;
            ContextPart = blog.Context.Length>20?blog.Context.Substring(0,20)+"...":blog.Context;
            ReleaseTime = blog.ReleaseTime;
            BlogId = blog.Id;
            Author = context.User.Single(x=>x.Id==blog.UserId).ShowName;
        }
        public string BlogId{get;set;}
        public string Title{get;set;}
        public string Author{get;set;}
        public string ContextPart{get;set;}
        public DateTimeOffset ReleaseTime { get; set; }
    }
}