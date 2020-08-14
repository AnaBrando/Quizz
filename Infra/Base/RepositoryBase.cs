using Domain.Interfaces.NovaPasta;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly BancoContext _db;
        public RepositoryBase() =>
            _db = new BancoContext();

        public RepositoryBase(BancoContext bancoContext)
        {
            this._db = bancoContext;
        }

        public async Task<TEntity> GetById(int id) =>
             await _db.Set<TEntity>().FindAsync(id);

        public async Task Update(TEntity e)
        {
            _db.Set<TEntity>().Update(e);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(TEntity e)
        {
            _db.Set<TEntity>().Remove(e);
            await _db.SaveChangesAsync();
        }

        public async Task<int> Add(TEntity e)
        {
            await _db.AddAsync(e);
             _db.SaveChanges();
            var q = _db.Quizz.Where(p => p.Equals(e));
            var i = q.Select(x => x.Quiz_id).FirstOrDefault();
            return i;
        }
        public async Task<ICollection<TEntity>> GetAll() =>
             await _db.Set<TEntity>().ToListAsync();

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}
