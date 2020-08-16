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
        
        public QuizzService(IQuizzRepository quizzRepository)
        {
            this.repo = quizzRepository;
        }


        public void Add(QuizzDTO user)
        {
            var quizz = new Quizz();
            quizz.DataInclusao = DateTime.Now;
            quizz.Descricao = user.Descricao;
            quizz.ProfessorSessao = user.ProfessorSessao;
            var x = repo.Add(quizz);
           
        }

        public Task<int> AddQuizz(QuizzDTO user)
        {
            var quizz = new Quizz();
            quizz.DataInclusao = DateTime.Now;
            quizz.Descricao = user.Descricao;
            quizz.ProfessorSessao = user.ProfessorSessao;
            var x = repo.AddQuizz(quizz);
            return x;
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

        public QuizzDTO GeyById(int id)
        {
            var result = repo.GetById(id).Result;
            var dto = new QuizzDTO();

            dto.Ativo = result.Ativo;
            dto.DataInclusao = result.DataInclusao;
            dto.Descricao = result.Descricao;
            dto.ProfessorId = result.ProfessorId;
            dto.ProfessorSessao = result.ProfessorSessao;
            dto.QuizzId = result.QuizzId;

            return dto;
        }

        public List<Quizz> QuizzByProfessorID(string id)
        {
            var quiss = repo.GetAll().Result.Where(x => x.ProfessorSessao == id);
            return quiss.ToList();
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
