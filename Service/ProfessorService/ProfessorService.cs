using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;

namespace Service.ProfessorService
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repo;

        public ProfessorService(IProfessorRepository repo)
        {
            _repo = repo;
        }
        public void Add(ProfessorDTO professor)
        {
            var obj = new Professor();
            obj.ProfessorSessao = professor.ProfessorSessao;
            _repo.Add(obj);
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(ProfessorDTO professor)
        {
            throw new System.NotImplementedException();
        }
    }
}
