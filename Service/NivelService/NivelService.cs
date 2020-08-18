using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.NivelService
{
    public class NivelService : INivelService
    {
        public readonly INivelRepository _repo;
    
        public NivelService(INivelRepository repo)
        {
            this._repo = repo;
           
        }
        public void Add(NivelDTO pergunta)
        {
            var nivel = new Nivel();
            nivel.Descricao = pergunta.Descricao;
            nivel.Pontuacao.PontuacaoId = pergunta.PontuacaoId;
            nivel.Pontuacao.PontuacaoId = pergunta.PontuacaoId;
            _repo.Add(nivel);
        }

        public ICollection<Nivel> buscarNiveis()
        {
            var result = _repo.GetAll().Result;
      
            return result;
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(NivelDTO pergunta)
        {
            throw new System.NotImplementedException();
        }
    }
}
