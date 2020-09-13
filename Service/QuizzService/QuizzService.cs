using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Service.QuizzService
{
    public class QuizzService : IQuizzService
    {
        public readonly IQuizzRepository repo;
        public readonly IPerguntaRepository repoPergunta;
        public readonly IRespostaRepository respostaRepository;
        public QuizzService(IQuizzRepository quizzRepository, IPerguntaRepository _repo,
            IRespostaRepository respostaRepo)
        {
            this.repo = quizzRepository;
            repoPergunta = _repo;
            respostaRepository = respostaRepo;
        }

        public Task<int> AddQuizz(QuizzDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuizzDTO, Quizz>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<QuizzDTO, Quizz>(user);
            var x = repo.AddQuizz(destination);
            return x;
        }

        public ICollection<Pergunta> buscarPerguntas(int id)
        {
            var perguntas = repoPergunta.GetAll().Result;
            perguntas = perguntas.Where(x => x.QuizzId == id).ToList();

            return perguntas;
        }

        public Pergunta buscarPerguntaParaIniciarQuizz(int id)
        {

            var respostasId = (from A in (respostaRepository.GetAll().Result)
                            select A.RespostaId).ToList();
            var teste = new List<Pergunta>();
            var pergunta = repoPergunta.GetAll().Result.Where(x => x.QuizzId == id );
            foreach (var item in pergunta)
            {
                var pgt = respostasId.Contains(item.RespostaId);
                if (pgt)
                {
                    teste.Add(item);
                }
            }
            return teste.Count() <=  0 ? pergunta.FirstOrDefault() : teste.FirstOrDefault(); 
          
        }

        public bool Delete(int id)
        {
            var quizz = repo.GetById(id).Result;
            if(quizz != null)
            {
                repo.Delete(quizz);
                return true;
            }
            return false;
        }

      

        public bool EditPost(QuizzDTO dto)
        {
            if(dto != null)
            {
                var data = DateTime.Now;
                var quizz = repo.GetById(dto.QuizzId).Result;
                if (quizz != null)
                {
                    quizz.Descricao = dto.Descricao;
                    quizz.Ativo = dto.Ativo;
                    quizz.DataInclusao = data;
                    repo.Update(quizz);
                    return true;
                }

            }
            return false;
        }

        public ICollection<Quizz> GetAll()
        {
            var result = repo.GetAll().Result.Where(x=>x.Ativo).ToList();
            return result;
        }

        public Quizz GeyById(int id)
        {
            var result = repo.GetById(id).Result;
            
         

            return result;
        }

        public List<Quizz> QuizzByProfessorID(string id)
        {
            var quiss = repo.GetAll().Result.Where(x => x.ProfessorSessao == id);
            
            var x = quiss.ToList();
            return x;
        }

        public void Save()
        {
            repo.Save();
        }

        public void Update(QuizzDTO user)
        {
            throw new NotImplementedException();
        }

       
    }
}
