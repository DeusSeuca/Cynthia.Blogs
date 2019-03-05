using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blogs.Server.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset ReleaseTime { get; set; } = new DateTimeOffset();
        public IEnumerable<Comment> Comments { get; set; }
    }
}