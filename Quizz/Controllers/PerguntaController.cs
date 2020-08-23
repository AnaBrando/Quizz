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
        public IActionResult IndexEdit(int id)
        {
            if(id > 0){
                var perguntas = _perguntaService.PerguntasByQuizzId(id);
                return View(perguntas);
            }
            return RedirectToAction("","");
        }
         public IActionResult Edit(int id){
             var pergunta = _perguntaService.getById(id);
             return View(pergunta);
         }
          public IActionResult Update(PerguntaDTO dto){
             if(dto.PerguntaId == 0){
                 dto.PerguntaId = 1;
             }
             _perguntaService.Update(dto);
             return RedirectToAction("IndexEdit","Pergunta",new {id = dto.QuizzId});
         }
         public void Delete(int id){
            _perguntaService.Delete(id);
         }
    }
}
