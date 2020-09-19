using Domain.Interfaces.NovaPasta;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
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
            try
            {
                _db.Set<TEntity>().Update(e);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.InnerException.ToString();
            }
           
        }

        public async Task Delete(TEntity e)
        {
            _db.Set<TEntity>().Remove(e);
            await _db.SaveChangesAsync();
        }

        public async Task Add(TEntity e)
        {
            try
            {
                await _db.AddAsync(e);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                 var x = ex.InnerException.ToString();
            }
            
            
        }
        public async Task<int> AddResposta(TEntity e)
        {
            try
            {
                await _db.AddAsync(e);
                _db.SaveChanges();
                var r = _db.Resposta.Where(p => p.Equals(e));
                var i = r.Select(x => x.RespostaId).FirstOrDefault();
                return i.Value;
            }
            catch (Exception ex)
            {
                var mens = ex.InnerException.Message.ToString();
            }
            return 0;
        }
        public async Task<int> AddQuizz(TEntity e)
        {
            try
            {
                await _db.AddAsync(e);
                _db.SaveChanges();
                var q = _db.Quizz.Where(p => p.Equals(e));
                var i = q.Select(x => x.QuizzId).FirstOrDefault();
                return i;
            }
            catch(Exception ex)
            {
              var mens=  ex.InnerException.Message.ToString();
            }
            return 0;
        }
        public async Task<ICollection<TEntity>> GetAll() =>
             await _db.Set<TEntity>().ToListAsync();

        
        public int Save()
        {
            return _db.SaveChanges();
        }

        public async Task<TEntity> GetByIdEstudante(string id) =>
            await _db.Set<TEntity>().FindAsync(id);
    }
}
