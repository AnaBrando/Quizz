using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;

namespace Service.PontuacaoService
{
    public class PontuacaoService : IPontuacaoService
    {
        public readonly IPontuacaoRepository _repo;

        public PontuacaoService(IPontuacaoRepository repo)
        {
            this._repo = repo;
        }
        public void Add(PontuacaoDTO pontuacao)
        {
            var ponto = new Pontuacao();
            ponto.Valor = (float)pontuacao.Valor;
            _repo.Add(ponto);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PerguntaDTO pontuacao)
        {
            throw new NotImplementedException();
        }
    }
}
