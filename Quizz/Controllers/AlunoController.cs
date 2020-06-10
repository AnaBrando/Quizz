using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Quizz()
        {
            return View();
        }
    }
}
