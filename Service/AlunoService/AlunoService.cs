using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Service.AlunoService
{
    public class AlunoService : IAlunoService
    {
        private readonly IPerguntaRepository _repo;
        private readonly IPontuacaoRepository _repoPontuacao;
        private readonly IEstudanteRepository _repoEstudante;
        public AlunoService(IPerguntaRepository repo, 
            IPontuacaoRepository repoPontuacao,
            IEstudanteRepository repoEstudante)
        {
            _repo = repo;
            _repoPontuacao = repoPontuacao;
            _repoEstudante = repoEstudante;
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

            var perguntas = _repo.GetAll().Result;
            return perguntas.ToList();

            ///*Teste Unitários*/
            //var perguntas = MockListaPergunta();

            //return perguntas;
        }

        public bool PontuarAluno(string id, double pontuacao)
        {
            var estudante = new Estudante();
            estudante.EstudanteId = id;
            estudante.EstudanteSessao = id;
            estudante.Pontuacao = (decimal)pontuacao;
            try
            {
                _repoEstudante.Add(estudante);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Teste unitário não acessa banco de dados
        //public List<Pergunta> MockListaPergunta()
        //{
        //    var json = File.ReadAllText(@"C:\Users\anabr\Documents\Quizz\Infra\MockUnitTests\Perguntas.json", Encoding.GetEncoding("iso-8859-1"));

        //    var perguntas = JsonConvert.DeserializeObject<List<Pergunta>>(json);

        //    return perguntas;
        //}
        public double Pontuou(int perguntaId)
        {
            var nivelId = _repo.GetById(perguntaId).Result.NivelId;
            var pontuacao = (from A in _repoPontuacao.GetAll().Result
                             where A.NivelId == nivelId
                             select A.Valor).First();
            return pontuacao;
        }


    }
}
