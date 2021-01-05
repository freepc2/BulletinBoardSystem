using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc6.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
