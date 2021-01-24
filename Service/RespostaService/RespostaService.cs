using AutoMapper;
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
        public readonly IEstudanteRespostaRepository _repositoryEstudanteResposta;
        public readonly IEstudanteRepository _repositoryEstudante;
        public readonly IMapper _mapper;
        public RespostaService(IRespostaRepository repo,
        IPerguntaRepository _repo,
        IEstudanteRepository _erepo,
        IQuizzRepository _quizz,
        IMapper mapper,
        IEstudanteRespostaRepository estudanteRespostaRepository)
        {
            _repositoyResposta = repo;
            _repositoryPergunta = _repo;
            _repositoryEstudante = _erepo;
            _repositoryQuizz = _quizz;
            _mapper = mapper;
            _repositoryEstudanteResposta = estudanteRespostaRepository;
        }
        public void Add(RespostaDTO reposta)
        {
            throw new NotImplementedException();
        }

        

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public RelatorioFinalObjectDTO GerarDadosRelatorio(int quizzId, int alunoId, string sessaoNome)
        {
            var perguntas = (from A in _repositoryQuizz.GetAll().Result
                             join B in _repositoryPergunta.GetAll().Result
                             on A.QuizzId equals B.QuizzId
                             where A.QuizzId == quizzId
                             select B
                             ).Distinct().ToList() ;
            var respostas = (from B in perguntas
                         join C in _repositoyResposta.GetAll().Result
                         on B.PerguntaId equals C.PerguntaId
                         join D in _repositoryEstudanteResposta.GetAll().Result
                         on C.RespostaId equals D.RespostaId
                         join E in _repositoryEstudante.GetAll().Result
                         on D.EstudanteId equals E.EstudanteId
                         select C).Distinct().ToList();
            var nomeAluno = (from B in perguntas
                             join C in _repositoyResposta.GetAll().Result
                             on B.PerguntaId equals C.PerguntaId
                             join D in _repositoryEstudanteResposta.GetAll().Result
                             on C.RespostaId equals D.RespostaId
                             join E in _repositoryEstudante.GetAll().Result
                             on D.EstudanteId equals E.EstudanteId
                             select E.Nome).Distinct().FirstOrDefault();
            var nomeQuizz = (from A in _repositoryQuizz.GetAll().Result
                             join B in _repositoryPergunta.GetAll().Result
                             on A.QuizzId equals B.QuizzId
                             where A.QuizzId == quizzId
                             select A.Descricao
                             ).Distinct().FirstOrDefault();
            var retorno = new RelatorioFinalObjectDTO
            {
                Perguntas = _mapper.Map<List<PerguntaDTO>>(perguntas),
                Resposta = _mapper.Map<List<RespostaDTO>>(respostas),
                NomeAluno = nomeAluno,
                NomeQuizz = nomeQuizz
            };

            return retorno;
        }

       

        public int GerarReposta(int estudanteId, int perguntaId,bool acertou)
        {
            var aluno = _repositoryEstudante.GetById(estudanteId).Result;
            var resposta = new Resposta
            {
                Descricao = DateTime.Now.ToString(),
                //EstudanteChave = estudanteId,
                PerguntaId = perguntaId,
                EstudanteId = estudanteId,
                Acertou = acertou
            };
            _repositoryEstudanteResposta.AddRespostaAsync(new EstudanteResposta
            {
                EstudanteId = aluno.EstudanteId,
                RespostaEstudante = resposta
            });

            var result = _repositoyResposta.GetAll()
                .Result.Where(x => x.RespostaId == resposta.RespostaId)
                .FirstOrDefault();

            return result.RespostaId;
            //return AddResposta(resposta);
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
