using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
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
        public IActionResult Edit(int id)
        {
            var quizz = _service.GeyById(id);
            return View(quizz);
        }
        public IActionResult Details(int id)
        {
            var quizz = _service.GeyById(id);
            return View(quizz);
        }
        public IActionResult Delete(int id)
        {
            var quizz = _service.Delete(id);
            if (quizz)
            {
                return RedirectToAction("Index", "Professor");
            }
            return View();
        }
        public IActionResult EditPost(QuizzDTO dto)
        {
            var result =_service.EditPost(dto);
            if (result)
            {
                return RedirectToAction("Index", "Professor");
            }
            return Redirect("Index");
        }
    }
}
