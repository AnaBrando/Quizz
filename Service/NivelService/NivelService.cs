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
            nivel.Pontuacao.PontuacaoId = pergunta.Pontuacao_ID;
            nivel.Pontuacao.PontuacaoId = pergunta.Pontuacao_ID;
            _repo.Add(nivel);
        }

        public PerguntaDTO buscarNiveis()
        {
            var x = _repo.GetAll().Result;
            var pergunta = new PerguntaDTO();
            if (x != null)
            {
                foreach (var item in x)
                {
                    var nivelDto = new NivelDTO();
                    nivelDto.Nivel_id = item.NivelId;
                    nivelDto.Descricao = item.Descricao;
                    nivelDto.Pontuacao_ID = item.PontuacaoId;
                    pergunta.niveis.Add(nivelDto);
                }
            }
            return pergunta;
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
