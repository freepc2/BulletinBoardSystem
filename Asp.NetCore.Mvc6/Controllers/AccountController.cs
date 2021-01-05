using Asp.NetCore.Mvc6.Models.AccountViewModels;
using Bbs.Bll;
using Bbs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc6.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserBll _userBll;
        public AccountController(UserBll userBll)
        {
            _userBll = userBll;
        }
        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Id,
                    PasswordHash = model.Password,
                    Email = model.Email
                };
                if (_userBll.AddUser(user))
                    RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        /// <summary>
        /// 로그인 페이지
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
