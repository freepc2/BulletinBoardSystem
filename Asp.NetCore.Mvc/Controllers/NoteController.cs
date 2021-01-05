using Bbs.Models;
using Bbs.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly UserBll _userBll;
        private readonly NoteBll _noteBll;
        public NoteController(
            UserBll userBll,
            NoteBll noteBll)
        {
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
            var model = _noteBll.GetNoteList();

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
            return View(model);
        }
    }
}
