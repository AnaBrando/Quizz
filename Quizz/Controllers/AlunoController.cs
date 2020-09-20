﻿using CrossCutting.User;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Quizz.Controllers
{
    public class AlunoController : Controller
    {
        public readonly IQuizzService _serviceQuizz;
        public readonly IAlunoService _alunoService;
        public readonly IRespostaService _respostaService;
        public readonly IPerguntaService _perguntaService;
        private readonly UserManager<Usuario> _userManager;

        public AlunoController(IQuizzService service, IAlunoService alunoService, 
            IRespostaService respostaService, IPerguntaService perguntaService,
            UserManager<Usuario> userManager)
        {
            _serviceQuizz = service;
            _alunoService = alunoService;
            _respostaService = respostaService;
            _perguntaService = perguntaService;
            _userManager = userManager;
        }
        
        public IActionResult IniciarQuizz(int id){
           var perguntas = _serviceQuizz.buscarPerguntaParaIniciarQuizz(id);
           return View(perguntas); 
        }

        public IActionResult Responder(int id,string resposta)
        {
            var estudante = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var pergunta = _perguntaService.getById(id);
            var acertou = _alunoService.Acertou(pergunta.PerguntaId, resposta);
            if (acertou)
            {
                
                var pontuacao = _alunoService.Pontuou(pergunta.PerguntaId);
                var pontuarAluno = _alunoService.PontuarAluno(estudante.Id, pontuacao);
                var i = _respostaService.GerarReposta(estudante.Id, pergunta.PerguntaId);

                return RedirectToAction("IniciarQuizz", "Aluno",new { id = pergunta.QuizzId });
            }
            return RedirectToAction("IniciarQuizz", "Aluno", new { id = pergunta.QuizzId }); ;
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

