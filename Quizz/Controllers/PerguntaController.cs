using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Application;
using System.Xml.Linq;
using Domain.DTO;

namespace Quizz.Controllers
{
    public class PerguntaController : Controller
    {
        public readonly IPerguntaService _perguntaService;
        public readonly INivelService _nivelService;
   
        public PerguntaController(IPerguntaService service, INivelService nivelService)
        {
            this._perguntaService=service;
            this._nivelService = nivelService;
        }

        public IActionResult Create(int id)
        {
            var niveis = _nivelService.buscarNiveis();
            var perguntaQuizz = _perguntaService.QuizzIT(id).Result;
            perguntaQuizz.niveis = niveis.niveis;
            return View(perguntaQuizz);
        }

        public IActionResult PerguntaPost(PerguntaDTO perguntaDTO)
        {
            if (perguntaDTO != null)
            {
                _perguntaService.Add(perguntaDTO);
            }
            return RedirectToAction("Create","Pergunta");
        }

    }
}
