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

        public RelatorioFinalDTO GerarDadosRelatorio(string descricao,string sessao,string sessaoNome)
        {
            var estudante = _repositoryEstudante.GetAll().Result;
            var query = (from A in estudante
                        where A.EstudanteSessao == sessao
                        select new RelatorioFinalDTO{
                                Pontuacao = A.Pontuacao,
                                NomeQuizz = descricao,
                                NomeAluno = sessaoNome
                            
                        }).Distinct().FirstOrDefault();
            var nivelQuizz = (from A in _repositoryPergunta.GetAll().Result
                                    join B in _repositoryQuizz.GetAll().Result
                                    on A.QuizzId equals B.QuizzId
                                    select A.NivelId).ToList();
            var pontuacaoTotal = (from A in nivelQuizz
                                    select A.Value).Sum();

            var porcentagem = ((query.Pontuacao * pontuacaoTotal)/100);
            query.Porcentagem = (double)porcentagem;
            return query;
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
