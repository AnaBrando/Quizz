using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class QuizzController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
