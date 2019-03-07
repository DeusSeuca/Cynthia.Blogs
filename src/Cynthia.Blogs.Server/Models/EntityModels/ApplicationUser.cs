using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Cynthia.Blogs.Server.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string ShowName { get; set; }
        public DateTimeOffset RegisterTime { get; set; } = DateTimeOffset.Now;
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
    }
}