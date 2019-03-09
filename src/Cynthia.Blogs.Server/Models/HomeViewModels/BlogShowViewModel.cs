using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Cynthia.Blogs.Server.Data;

namespace Cynthia.Blogs.Server.Models
{
    public class BlogShowViewModel
    {
        public BlogShowViewModel(Blog blog,BlogDbContext context)
        {
            Title = blog.Title;
            Context = blog.Context;
            Author = context.User.Single(x=>x.Id==blog.UserId).ShowName;
            Comments = context.Comment.Where(x=>x.BlogId==blog.Id)
                .OrderBy(x=>x.CommentTime)
                .Select(x=>new CommentShowViewModel(x,context));
        }
        public string Title{get;set;}
        public string Context{get;set;}
        public string Author{get;set;}
        public DateTimeOffset ReleaseTime { get; set; }
        public IEnumerable<CommentShowViewModel> Comments { get; set; }
    }
}