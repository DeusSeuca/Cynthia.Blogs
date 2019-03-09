using System;
using System.Linq;
using Cynthia.Blogs.Server.Data;
using Cynthia.Blogs.Server.Models;

public class CommentShowViewModel
{
    public CommentShowViewModel(Comment comment)
    {
        CommentTime = comment.CommentTime;
        Context = comment.Context;
        BlogId = comment.BlogId;
        UserId = comment.UserId;
    }
    public DateTimeOffset CommentTime { get; set; }
    public string Context{get;set;}
    public string UserId { get; set; }
    public string ShowName { get; set; }
    public string BlogId { get; set; }
}