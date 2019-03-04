using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blog.Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset RegisterTime { get; set; } = new DateTimeOffset();
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
    }
}