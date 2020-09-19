using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.NovaPasta
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity e);
        Task<int> AddQuizz(TEntity e);
        Task Update(TEntity e);
        Task Delete(TEntity e);
        int Save();
        Task<TEntity> GetByIdEstudante(string id);

        Task<int> AddResposta(TEntity e);
    }
}

