using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly IQuizzService _service;

        public ProfessorController(IQuizzService service)
        {
            _service = service;
        }
        public IActionResult Index(string id)
        {
            if (id != null && !string.IsNullOrEmpty(id))
            {
                var x = _service.QuizzByProfessorID(id);
                return View(x);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
