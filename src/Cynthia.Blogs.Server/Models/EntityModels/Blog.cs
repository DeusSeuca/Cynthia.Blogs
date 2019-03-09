using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blogs.Server.Models
{
    public class Blog
    {
        [Key]
        public string Id { get; set; }
        public string Title{get;set;}
        public string Context{get;set;}
        public string UserId{get;set;}
        public ApplicationUser User{get;set;}
        public DateTimeOffset ReleaseTime { get; set; } = DateTimeOffset.Now;
        public IEnumerable<Comment> Comments { get; set; }
    }
}