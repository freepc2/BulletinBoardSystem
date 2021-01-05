using Asp.NetCore.Mvc6.Models.AccountViewModels;
using Bbs.Bll;
using Bbs.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc6.Controllers
{
    public class AccountController : Controller
    {
        /*
         *   1. session 방식으로 로그인
         *   2. password 암호화
         */
        private readonly UserBll _userBll;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserBll userBll,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userBll = userBll;
            _signInManager = signInManager;
            _userManager = userManager;
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
                new PasswordHasher<string>().HashPassword(null, model.Password);
                var user = new User
                {
                    UserName = model.Id,
                    PasswordHash = new PasswordHasher<string>().HashPassword(null, model.Password),
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
        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var account = await _accountService.LogInAsync(model.Id, model.Password);

            if (account != null)
            {
                var claims = BuildClaims(account);

                var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity));

                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError(string.Empty, _localizer["사용자 이메일 혹은 비밀번호가 올바르지 않습니다."]);
            return View(model);
        }
        public IActionResult ChangePassword()
        {
            return View();
        }


        private IList<Claim> BuildClaims(SignInManager<User> commonAccount)
        {
            var roles = "User";
            if (commonAccount.IsSuperAdmin)
            {
                roles = "Admin";
            }
            else
            {
                roles = commonAccount.FirstSubscriber ? "Manager" : "User";
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, $"{commonAccount.Id}"),
                new Claim("Email", commonAccount.Email),
                new Claim("Name", commonAccount.UserName),
                new Claim(ClaimTypes.Role, roles),

            };

            return claims;
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
