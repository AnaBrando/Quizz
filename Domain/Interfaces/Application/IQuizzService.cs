using Domain.DTO;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IQuizzService
    {
        Task<int> AddQuizz(QuizzDTO user);
        void Update(QuizzDTO user);
        Quizz GeyById(int id);
        List<Quizz> QuizzByProfessorID(string id);
        void Save();
        Pergunta buscarPerguntaParaIniciarQuizz(int id,int estudanteId);
        ICollection <Quizz> GetAll();
        bool Delete(int id);
        bool EditPost(QuizzDTO dto);
        ICollection<Pergunta> buscarPerguntas(int id);

        IQueryable<object> RelatorioProfessor(int quizzId);
    }
}
