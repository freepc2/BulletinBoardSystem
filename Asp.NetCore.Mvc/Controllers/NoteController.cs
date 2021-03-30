using Bbs.Bll;
using Bbs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Asp.NetCore.Mvc.Search.Services;
using Asp.NetCore.Mvc.Models;
using Asp.NetCore.Mvc.Search;

namespace Asp.NetCore.Mvc.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly NoteBll _noteBll;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManger;
        private readonly ISearchService _searchService;

        public NoteController(
            NoteBll noteBll,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ISearchService searchService)
        {
            _noteBll = noteBll;
            _userManager = userManager;
            _signInManger = signInManager;
            _searchService = searchService;
        }
        /// <summary>
        /// 게시판 목록 표시
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pagSize = 10;

            var notes = _noteBll.GetNoteList();
            var nots = _noteBll.GetNoteList(pageNumber, pagSize);
            var model = new SearchViewModel();
            model.SearchResult = _searchService.GetResult(notes, pageNumber, pagSize);

            return View(model);
        }

        [HttpGet]
        public IActionResult Post(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(Note model)
        {
            if(ModelState.IsValid)
            {
                model.UserNo = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                model.Date = DateTime.Now;
                _noteBll.PostNote(model);
                return RedirectToAction("Index", "Note");
            }
            return View(model);
        }

        public IActionResult Detail(int No)
        {
            var note = _noteBll.GetNoteAndUpdateView(No);
            return View(note);
        }
        [HttpGet]
        public IActionResult Search(string query, int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pagSize = 10;
            var model = new SearchViewModel();
            if (string.IsNullOrWhiteSpace(query))
            {
                model.SearchResult = new SearchResult();
            }
            else
            {
                var notes = _noteBll.GetNoteList();
               // model.SearchResult = _searchService.GetResult(notes, pageNumber, pagSize);
                model.SearchResult = _searchService.GetSearchResult(notes, query, pageNumber, pagSize);
            }
            model.SearchResult.SearchQuery = query;
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int No)
        {
            
            var note = _noteBll.GetNoteAndUpdateView(No);
            // 같은 내용인지 확인
            if(note.UserNo == Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return View(note);
            }
            else
                return RedirectToAction("Index", "Note");
        }

        [HttpPost]
        public IActionResult Edit(Note model)
        {


            // model의 번호가 없음... -> 업데이트되지 않고 신규 목록으로 추가됨
            // 기존 model을 받아오는 방식을 구현해야 함
            if(model.UserNo == Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                if (ModelState.IsValid)
                {
                   // model.UserNo = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    _noteBll.UpdateNote(model);
                    return RedirectToAction("Index", "Note");
                }
            }
            ModelState.AddModelError(string.Empty,"작성자가 아닙니다.");
            return View(model);
        }

        #region Helpers
        #endregion
    }
}
