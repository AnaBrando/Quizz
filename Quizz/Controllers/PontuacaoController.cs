using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class PontuacaoController : Controller
    {
        public readonly IPontuacaoService _service;

        public PontuacaoController(IPontuacaoService service)
        {
            this._service = service;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Create");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreatePost(PontuacaoDTO pontuacaoDTO)
        {
            if(pontuacaoDTO != null)
            {
                _service.Add(pontuacaoDTO);
            }
            return RedirectToAction("Index");
        }
    }
}
