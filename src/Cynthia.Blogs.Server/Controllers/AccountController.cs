using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cynthia.Blogs.Server.Models;
using Cynthia.Blogs.Server.Models.HomeViewModels;
using Cynthia.Blogs.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cynthia.Blogs.Server.Controllers
{
    public class AccountController : Controller
    {
        //private readonly SignInManager<User> _signInManager;
        //private readonly UserManager<User> _userManager;
        private readonly IBusiness _business;

        public AccountController(IBusiness business)//,SignInManager<User> signInManager, UserManager<User> userManager)
        {
            //_signInManager = signInManager;
            //_userManager = userManager;
            _business = business;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInfo info)
        {
            if(!ModelState.IsValid)
                return View(info);
            if (await _business.Login(info))
                return RedirectToAction("Index","Home");
            ModelState.AddModelError("","用户名或密码不正确!");
            return View(info);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _business.Logout();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInfo info)
        {
            if(!ModelState.IsValid)
                return View(info);
            if (await _business.Register(info))
                return RedirectToAction(nameof(Login));
            ModelState.AddModelError("","注册失败,该用户信息已经被注册!");
            return View(info);
        }
    }
}
