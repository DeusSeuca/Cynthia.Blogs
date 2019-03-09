using System.Collections.Generic;

namespace Cynthia.Blogs.Server.Models.HomeViewModels
{
    public class BlogListViewModel
    {
        public IEnumerable<BlogListItemViewModel> Blogs{get;set;}
    }
}