using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cynthia.Blogs.Server.ViewComponets
{
    public class TestViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("HelloWorld","测试");
        }
    }
}
