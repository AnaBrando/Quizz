using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class NivelController : Controller
    {
        private readonly INivelService service;

        public NivelController(INivelService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Create");
        }
        public IActionResult Create()
        {
            var pontuacoes = service.buscarNiveis();
            return View();
        }
    }
}
