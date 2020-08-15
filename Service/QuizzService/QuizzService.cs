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
            quizz.ProfessorSessao = user.Professor_ID;
            var x = repo.Add(quizz);
           
        }

        public Task<int> AddQuizz(QuizzDTO user)
        {
            var quizz = new Quizz();
            quizz.DataInclusao = DateTime.Now;
            quizz.Descricao = user.Descricao;
            quizz.ProfessorSessao = user.Professor_ID;
            var x = repo.AddQuizz(quizz);
            return x;
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
