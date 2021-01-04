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
            NoteBll noteBll
            )
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
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Add(Note model)
        {
            return View(model);
        }
    }
}
