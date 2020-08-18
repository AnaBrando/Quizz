using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Application;
using System.Xml.Linq;
using Domain.DTO;
using Domain.Models;
using System.Linq;

namespace Quizz.Controllers
{
    public class PerguntaController : Controller
    {
        public readonly IPerguntaService _perguntaService;
        public readonly INivelService _nivelService;
        public readonly IQuizzService _quizzService;


        public PerguntaController(IPerguntaService service, INivelService nivelService, IQuizzService quizzService)
        {
            this._perguntaService=service;
            this._nivelService = nivelService;
            this._quizzService = quizzService;
        }

        public IActionResult Create(int id)
        {
            var niveis = _nivelService.buscarNiveis();
            var quizz = _quizzService.GeyById(id);
            var perguntas = _quizzService.buscarPerguntas(id);
            quizz.Pergunta = perguntas;
            if (quizz.Pergunta.Count() < 10)
            {
                var pergunta = new PerguntaDTO();
                pergunta.Quizz = quizz;
                pergunta.QuizzId = quizz.QuizzId;
                foreach (var item in niveis)
                {
                    pergunta.niveis.Add(item);
                    
                }
                return View(pergunta);

            }
            ModelState.AddModelError("Invalid!", "Usuário Inválido");
            return RedirectToAction("Voltar", "Professor");
        }

        public IActionResult PerguntaPost(PerguntaDTO perguntaDTO)
        {
            var Id = perguntaDTO.QuizzId;
            if (perguntaDTO != null)
            {
                _perguntaService.Add(perguntaDTO);
            }
            return RedirectToAction("Create","Pergunta",new { id= Id });
        }

    }
}
