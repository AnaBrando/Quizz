using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.RespostaService
{
    public class RespostaService : IRespostaService
    {
        public readonly IRespostaRepository _repositoyResposta;
        public readonly IQuizzRepository _repositoryQuizz;

        public readonly IPerguntaRepository _repositoryPergunta;
        public readonly IEstudanteRepository _repositoryEstudante;

        public RespostaService(IRespostaRepository repo,
        IPerguntaRepository _repo,
        IEstudanteRepository _erepo,
        IQuizzRepository _quizz)
        {
            _repositoyResposta = repo;
            _repositoryPergunta = _repo;
            _repositoryEstudante = _erepo;
            _repositoryQuizz = _quizz;
        }
        public void Add(RespostaDTO reposta)
        {
            throw new NotImplementedException();
        }

        public int AddResposta(Resposta pergunta)
        {
            var i = _repositoyResposta.AddResposta(pergunta);
            var indice = i.Result;
            return indice;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public RelatorioFinalObjectDTO GerarDadosRelatorio(int quizzId, int alunoId, string sessaoNome)
        {
           var query = (from A in _repositoyResposta.GetAll().Result
                        join B in _repositoryEstudante.GetAll().Result
                        on A.EstudanteId equals B.EstudanteId 
                        join C in _repositoryPergunta.GetAll().Result
                        on A.PerguntaId equals C.PerguntaId
                        join D in _repositoryQuizz.GetAll().Result
                        on C.QuizzId equals D.QuizzId
                        where A.EstudanteId == alunoId && C.QuizzId == quizzId
                        && D.QuizzId == quizzId
                        select new RelatorioFinalDTO{
                                NomeAluno = B.Nome,
                                NomeQuizz = D.Descricao
                        }).Distinct().FirstOrDefault();
           var resposta = new List<RespostaDTO>();
           var perguntas = (from A in _repositoryPergunta.GetAll().Result
                            where A.QuizzId == quizzId
                            select A).Distinct().ToList();
            foreach(var x in perguntas){
                var respostas =(from A in _repositoyResposta.GetAll().Result
                                join B in _repositoryPergunta.GetAll().Result
                                on A.PerguntaId equals B.PerguntaId
                                where A.EstudanteId == alunoId && A.PerguntaId == x.PerguntaId
                                select new RespostaDTO{
                                    EstudanteId = alunoId,
                                    Acertou = A.Acertou,
                            }).Distinct().FirstOrDefault();
                resposta.Add(respostas);
                     
            }
            query.Resposta = resposta;
            var retorno = new RelatorioFinalObjectDTO{ Perguntas = perguntas,Relatorio = query,quiizId = quizzId};
            
            return retorno;
            
        }

        public int GerarReposta(string EstudanteId,int perguntaId)
        {
            Resposta resposta = new Resposta();
            resposta.Descricao = DateTime.Now.ToString();
            resposta.EstudanteChave = EstudanteId;
            resposta.PerguntaId = perguntaId;
            resposta.EstudanteId = 0;
            return AddResposta(resposta);
        }

        public void GerarRepostaIncorreta(int estudanteId, int perguntaId)
        {
           Resposta resposta = new Resposta();
            resposta.Descricao = DateTime.Now.ToString();
            resposta.PerguntaId = perguntaId;
            resposta.EstudanteId = estudanteId;
            _repositoyResposta.Add(resposta);
        }

        public ICollection<RespostaDTO> GetAll(int quiizId)
        {
            throw new NotImplementedException();
        }

        public void PDF()
        {
           
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(RespostaDTO pergunta)
        {
            throw new NotImplementedException();
        }

        public void Update(Resposta pergunta)
        {
            throw new NotImplementedException();
        }

        ICollection<Resposta> IRespostaService.GetAll(int quiizId)
        {
            throw new NotImplementedException();
        }

        
    }
}
