using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;

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
            quizz.DataInclusão = DateTime.Now;
            quizz.Descricao = user.Descricao;
            quizz.Professor_ID = user.Professor_ID;
            repo.Add(quizz);
        }

        public void Update(QuizzDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
