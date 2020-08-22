using Domain;
using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PerguntaService
{
    public class PerguntaService : IPerguntaService
    {

        public readonly IPerguntaRepository perguntaRepository;
        public readonly IQuizzRepository _quizzRepository;
        public readonly IQuizzService _quizzService;
        public PerguntaService(IPerguntaRepository repo, IQuizzService quizzService
            , IQuizzRepository quizzRepository)
        {
            this.perguntaRepository = repo;
            _quizzRepository = quizzRepository;
            _quizzService = quizzService;
        }

        
        public void Add(PerguntaDTO pergunta)
        {
            if(pergunta != null)
            {
                var quizz = _quizzService.GeyById(pergunta.QuizzId);
                if (quizz != null)
                {
                    var obj = new Pergunta();
                    obj.Descricao = pergunta.Descricao;
                    obj.OpcaoA = pergunta.OpcaoA;
                    obj.OpcaoB = pergunta.OpcaoB;
                    obj.OpcaoC = pergunta.OpcaoC;
                    obj.OpcaoD = pergunta.OpcaoD;
                    obj.OpcaoCerta = pergunta.OpcaoCerta;
                    obj.NivelId = pergunta.NivelId;
                    obj.QuizzId = pergunta.QuizzId;
                    perguntaRepository.Add(obj);
                    quizz.Pergunta.Add(obj);
                    _quizzRepository.Update(quizz);


                }
            }
        }

        public List<Pergunta> PerguntasByQuizzId(int id)
        {
           var perguntas = perguntaRepository.GetAll().Result.Where(x=>x.QuizzId == id).ToList();
           return perguntas;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PerguntaDTO pergunta)
        {
            throw new NotImplementedException();
        }

        async Task<Pergunta> IPerguntaService.QuizzIT(int id)
        {
            var perguntaDTO = new Pergunta();
            perguntaDTO.QuizzId =id;
            return perguntaDTO;
        }
    }
}
