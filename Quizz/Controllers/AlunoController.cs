using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Quizz.Controllers
{
    public class AlunoController : Controller
    {
        public readonly IQuizzService _serviceQuizz;
        public AlunoController(IQuizzService service)
        {
            _serviceQuizz = service;
        }
        
        public IActionResult IniciarQuizz(int id){
           var perguntas = _serviceQuizz.buscarPerguntaParaIniciarQuizz(id);
           return View(perguntas); 
        }

        public void Responder(int id,string resposta)
        {
           
        }
   
        public IActionResult Index(string id)
        {
           var quizz = _serviceQuizz.GetAll();
           if(quizz != null || quizz.Count > 0){
                foreach(var item in quizz){
                 var perguntas = _serviceQuizz.buscarPerguntas(item.QuizzId);
                 if(perguntas.Count > 0 || perguntas != null){
                        item.Pergunta = perguntas;
                 }
                
           }
           }
           
           return View(quizz);
        }
       
    }
}

