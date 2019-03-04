using System.ComponentModel.DataAnnotations;

namespace Cynthia.Blog.Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName{get;set;}
        public string LoginName{get;set;}
    }
}