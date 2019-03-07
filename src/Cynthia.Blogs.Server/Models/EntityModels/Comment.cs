using System;
using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blogs.Server.Models
{
    //Comment on Blog
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public DateTimeOffset CommentTime { get; set; } = new DateTimeOffset();
        public string Context{get;set;}
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}