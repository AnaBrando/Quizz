using Domain.DTO;

namespace Domain.Interfaces.Application
{
    public interface IProfessorService
    {
        void Add(ProfessorDTO professor);
        void Update(ProfessorDTO professor);
        void Save();
    }
}
