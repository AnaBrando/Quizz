using System;
using System.Net.Http;
using System.Text;
using CrossCutting.User;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Quizz.Controllers
{

    public class AlunoController : Controller
    {
        public readonly IQuizzService _serviceQuizz;
        public readonly IAlunoService _alunoService;
        public readonly IRespostaService _respostaService;
        public readonly IPerguntaService _perguntaService;
        private readonly IViewRenderService _viewRenderService;
        private readonly IPdfGeneratorService _pdfService;
        private readonly UserManager<Usuario> _userManager;

        public AlunoController(IQuizzService service, IAlunoService alunoService, 
            IRespostaService respostaService, IPerguntaService perguntaService,
            IViewRenderService viewRender,
            IPdfGeneratorService pdfGenerator,
            UserManager<Usuario> userManager)
        {
            _serviceQuizz = service;
            _alunoService = alunoService;
            _respostaService = respostaService;
            _perguntaService = perguntaService;
            _userManager = userManager;
            _pdfService = pdfGenerator;
            _viewRenderService = viewRender;
        }
        public async System.Threading.Tasks.Task<IActionResult> RelatorioFinalAsync(string nomeQuizz,string sessao,string sessaoNome){
      
            var result = _respostaService.GerarDadosRelatorio(nomeQuizz,sessao,sessaoNome);
            var dados = _viewRenderService.RenderToStringAsync("Aluno/RelatorioFinal", result).Result;
            var expected = JsonConvert.SerializeObject(new { html = dados });
            var jason = expected.Replace(@"\\n","");
            var jason2 = jason.Replace(@"\","");
            var jason3 = jason2.Replace(@"n","");
            var teste2 = jason3.Replace("\"", "");
            Console.WriteLine(teste2);
            string json = JsonConvert.SerializeObject(teste2);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62626");
                var teste = new StringContent(json, Encoding.UTF8, "application/json");
            
                var pdf = await client.PostAsync("http://localhost:62626", teste);
                var r = new FileContentResult(await pdf.Content.ReadAsByteArrayAsync(),pdf.Content.Headers.ContentType.MediaType);
                
                return r;
            
            }
        }
        public IActionResult IniciarQuizz(int id){
            var sessaoNome =  User.Identity.Name;
            var sessao =  _userManager.FindByNameAsync(sessaoNome).Result.Id;

            var nomeQuizz = _serviceQuizz.GeyById(id).Descricao;
            id=9;
            if(id == 9){
                return RedirectToAction("RelatorioFinal","Aluno",new { nomeQuizz = nomeQuizz,sessao = sessao,sessaoNome = sessaoNome});
                //return RedirectToAction("RelatorioFinal",nomeQuizz,sessao,sessaoNome);
            }
            else{
                var perguntas = _serviceQuizz.buscarPerguntaParaIniciarQuizz(id);
                return View(perguntas);
            }
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

