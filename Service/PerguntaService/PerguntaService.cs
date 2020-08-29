using AutoMapper;
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

        public readonly INivelRepository nivelRepository;
        public readonly IPerguntaRepository perguntaRepository;
        public readonly IQuizzRepository _quizzRepository;
        public readonly IQuizzService _quizzService;
        public PerguntaService(IPerguntaRepository repo, IQuizzService quizzService
            , IQuizzRepository quizzRepository,INivelRepository nivel)
        {
            this.perguntaRepository = repo;
            _quizzRepository = quizzRepository;
            _quizzService = quizzService;
            nivelRepository = nivel;
        }

        
        public void Add(PerguntaDTO pergunta)
        {
            if(pergunta != null)
            {

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<PerguntaDTO, Pergunta>();
                });
                IMapper iMapper = config.CreateMapper();
                var destination = iMapper.Map<PerguntaDTO,Pergunta>(pergunta);
                var quizz = _quizzService.GeyById(pergunta.QuizzId);
                if (quizz != null)
                {
                    perguntaRepository.Add(destination);
                    quizz.Pergunta.Add(destination);
                    _quizzRepository.Update(quizz);
                }
            }
        }

        public void Delete(int id)
        {
            var pergunta = perguntaRepository.GetById(id).Result;
            perguntaRepository.Delete(pergunta);
        }

        public PerguntaDTO getById(int id)
        {
            var pergunta = perguntaRepository.GetById(id).Result;
            var dto = new PerguntaDTO();
            dto.Descricao= pergunta.Descricao;
            dto.OpcaoA = pergunta.OpcaoA;
            dto.OpcaoB = pergunta.OpcaoB;
            dto.OpcaoC = pergunta.OpcaoC;
            dto.OpcaoD = pergunta.OpcaoD;
            dto.QuizzId = pergunta.QuizzId;
            dto.PerguntaId = pergunta.PerguntaId;
            dto.OpcaoCerta = pergunta.OpcaoCerta;
            dto.NivelId = pergunta.NivelId;
            var niveis = nivelRepository.GetAll().Result.ToList();
            dto.niveis = niveis;
            return dto;
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

        public void Update(PerguntaDTO dto)
        {
            var pergunta = perguntaRepository.GetById(dto.PerguntaId).Result;
            pergunta.Descricao = dto.Descricao;
            pergunta.OpcaoA = dto.OpcaoA;
            pergunta.OpcaoB = dto.OpcaoB;
            pergunta.OpcaoC = dto.OpcaoC;
            pergunta.OpcaoD = dto.OpcaoD;
            pergunta.PerguntaId=dto.PerguntaId;
            pergunta.OpcaoCerta=dto.OpcaoCerta;
            pergunta.NivelId= dto.NivelId;
            perguntaRepository.Update(pergunta);
        }

        async Task<Pergunta> IPerguntaService.QuizzIT(int id)
        {
            var perguntaDTO = new Pergunta();
            perguntaDTO.QuizzId =id;
            return perguntaDTO;
        }
    }
}
