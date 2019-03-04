using System;
using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blog.Server.Models
{
    //Comment on Blog
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset CommentTime { get; set; } = new DateTimeOffset();
        public int UserId { get; set; }
        public User User { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}