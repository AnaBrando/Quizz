using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Service.AlunoService
{
    public class AlunoService : IAlunoService
    {
        private readonly IPerguntaRepository _repo;

        public AlunoService(IPerguntaRepository repo)
        {
            _repo = repo;
        }


        public bool Acertou(int perguntaId,string resposta)
        {
            var pergunta = GetPerguntas().Where(x=>x.PerguntaId == perguntaId).FirstOrDefault();
            if(pergunta.OpcaoCerta == resposta)
            {
                return true;
            }
            return false;
        }

        public List<Pergunta> GetPerguntas()
        {
            /*banco de dados*/
       
            //var perguntas = _repo.GetAll().Result;
            //return perguntas;

            /*Teste Unitários*/
            var perguntas = MockListaPergunta();

            return perguntas;


        }
        //Teste unitário não acessa banco de dados
        public List<Pergunta> MockListaPergunta()
        {
            var json = File.ReadAllText(@"C:\Users\anabr\Documents\Quizz\Infra\MockUnitTests\Perguntas.json", Encoding.GetEncoding("iso-8859-1"));

            var perguntas = JsonConvert.DeserializeObject<List<Pergunta>>(json);

            return perguntas;
        }
        public bool Pontuou(int respostaId)
        {
            return true;
        }
    }
}
