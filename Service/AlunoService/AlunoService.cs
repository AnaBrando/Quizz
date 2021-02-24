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
        private readonly IRespostaRepository _repoResposta;
        private IPerguntaRepository object1;
        private IPontuacaoRepository object2;
        private IEstudanteRepository object3;

        public AlunoService(IPerguntaRepository object1, IPontuacaoRepository object2, IEstudanteRepository object3)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.object3 = object3;
        }

        public AlunoService(IPerguntaRepository repo, 
            IPontuacaoRepository repoPontuacao,
            IEstudanteRepository repoEstudante,
            IRespostaRepository repoResposta)
        {
            _repo = repo;
            _repoPontuacao = repoPontuacao;
            _repoEstudante = repoEstudante;
            _repoResposta = repoResposta;
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

        public void Add(EstudanteDTO dto)
        {
            try{
                if(dto != null){
                var modelo = new Estudante{EstudanteSessao = dto.EstudanteSessao,Pontuacao = 0};
               _repoEstudante.Add(modelo);
           }
            }catch(Exception e){

            }
          
        }

        public List<Estudante> GetAll()
        {
           return _repoEstudante.GetAll().Result.ToList();
        }

        public EstudanteDTO GetbySession(string sessao)
        {
            var estudante = _repoEstudante.GetAll().Result.Where(x=>x.EstudanteSessao == sessao).FirstOrDefault();
            var dto = new EstudanteDTO {EstudanteSessao = estudante.EstudanteSessao,Pontuacao = estudante.Pontuacao,
            EstudanteId = estudante.EstudanteId };
            return dto;
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
            var respsotas = _repoResposta.GetAll().Result;
            var index = respsotas.Count();
            var ponteiro = index + 1;
           
          
            var estudanteBanco = _repoEstudante.GetAll().Result.Where(x=>x.EstudanteSessao == id).FirstOrDefault();
            if(estudanteBanco != null){
                    estudanteBanco.Pontuacao = estudanteBanco.Pontuacao + (decimal)pontuacao;
                    _repoEstudante.Update(estudanteBanco);
                    return true;
            }else{
                var estudante = new Estudante();
                estudante.EstudanteSessao = id;
                estudante.Pontuacao = (decimal)pontuacao;
           
                _repoEstudante.Add(estudante);
                return true;
         
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
