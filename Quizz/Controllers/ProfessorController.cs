using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        private readonly IPerguntaService _PerguntaService;

        private readonly IAlunoService _estudanteService;
          public readonly IRespostaService _respostaService;
   

        public ProfessorController(IQuizzService service, 
            UserManager<Usuario> user,IPerguntaService perguntaService,
            IAlunoService alunoService, IRespostaService respostaService)
        {
            _userManager = user;
            _service = service;
            _respostaService = respostaService;
            _estudanteService = alunoService;
            _PerguntaService = perguntaService;
        }
        public IActionResult Index(string id)
        {
            var sessao =  _userManager.FindByIdAsync(id).Result.RoleName;
            
            if(sessao.Equals("Aluno")){
                       return RedirectToAction("Index", "Aluno", new { id = id });
            }
            else if(sessao.Equals("Professor")){
                if (id != null && !string.IsNullOrEmpty(id))
            {
                var x = _service.QuizzByProfessorID(id);
                if(x != null && x.Count > 0)
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
            }
            ModelState.AddModelError(string.Empty, "Limite de Perguntas Alcançado");
            return RedirectToAction("Voltar", "Professor");
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
        public async System.Threading.Tasks.Task<IActionResult> RelatorioProfessor(int QuizzId){
            var report = new List<RelatorioFinalObjectDTO>();
            QuizzId = 1;
            var perguntas = _PerguntaService.PerguntasByQuizzId(QuizzId).Select(x=>x.PerguntaId);
            var alunos = (from A in _respostaService.GetAll()
                            join B in _estudanteService.GetAll()
                            on A.EstudanteId equals B.EstudanteId
                            select new EstudanteDTO{
                                    EstudanteId = A.EstudanteId,
                                    Nome = B.Nome
                            }).Distinct(); 
             
            foreach (var item in alunos)
            {
                 var result = _respostaService.GerarDadosRelatorio(QuizzId,item.EstudanteId,item.Nome);
                 report.Add(result);
            }
         
            using (var client = new HttpClient())
            {
                
            var vaisefuder = await client.PostAsJsonAsync("http://localhost:62626/PostRelatorio", report);
                var r = new FileContentResult(await vaisefuder.Content.ReadAsByteArrayAsync(),vaisefuder.Content.Headers.ContentType.MediaType);
                return r;
            }
        
         }
    }
}
