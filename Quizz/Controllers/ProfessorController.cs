using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCutting.User;
using Domain.DTO;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IQuizzService _service;
   

        public ProfessorController(IQuizzService service, UserManager<Usuario> user)
        {
            _userManager = user;
            _service = service;
        }
        public IActionResult Index(string id)
        {
          
            if (id != null && !string.IsNullOrEmpty(id))
            {
                var x = _service.QuizzByProfessorID(id);
                if(x != null)
                {
                    foreach (var item in x)
                    {
                        var perguntas = _service.buscarPerguntas(item.QuizzId);
                        if(perguntas != null)
                        {
                            foreach (var pgt in perguntas)
                            {
                                item.Pergunta.Add(pgt);
                            }
                        }
                    }
                }
                return View(x);
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Voltar()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            return RedirectToAction("Index", "Professor", new { id = user });
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
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var quizz = _service.Delete(id);
            if (quizz)
            {
                return RedirectToAction("Index", "Professor", new { id = user});
            }
            return View();
        }
        public IActionResult EditPost(QuizzDTO dto)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var result =_service.EditPost(dto);
            if (result)
            {
                var userId = User.Identity.IsAuthenticated;
                return RedirectToAction("Index", "Professor", new { id = user });
            }
            return Redirect("Index");
        }
    }
}
