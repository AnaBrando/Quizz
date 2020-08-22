using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class AlunoController : Controller
    {
        public readonly IQuizzService _service;
        public AlunoController(IQuizzService service)
        {
            _service = service;
        }
        public IActionResult IniciarQuizz(string id){
           return View(); 
        }
        public IActionResult Index(string id)
        {
           var quizz = _service.GetAll();
           if(quizz != null || quizz.Count > 0){
                foreach(var item in quizz){
                 var perguntas = _service.buscarPerguntas(item.QuizzId);
                 if(perguntas.Count > 0 || perguntas != null){
                        item.Pergunta = perguntas;
                 }
                
           }
           }
           
           return View(quizz);
        }
       
    }
}

