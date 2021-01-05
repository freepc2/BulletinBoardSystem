using Bbs.Models;
using Bbs.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Asp.NetCore.Mvc.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly UserBll _userBll;
        private readonly UserManager<User> _userManager;
        private readonly NoteBll _noteBll;
        public NoteController(
            UserManager<User> userManager,
            UserBll userBll,
            NoteBll noteBll)
        {
            _userManager = userManager;
            _userBll = userBll;
            _noteBll = noteBll;
        }
        /// <summary>
        /// 현재 게시판 내용 출력
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = _noteBll.GetNoteList()
                .OrderByDescending(n=>n.No)
                .ToList();

            return View(model);
        }
        
        [HttpGet]   // 해당 index로 들어올 경우 시작됨
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost] // 해당 index에서 나갈때, 다른곳으로 이동시에 사용됨
        public IActionResult Add(Note model)
        {
            //Get User.Id
            model.UserNo = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //Get User.Name
            //var appUser = await _userManager.GetUserAsync(User);
            
            if (ModelState.IsValid)
            {
                _noteBll.PostNote(model);
            }
            return View(model);
        }
    }
}
