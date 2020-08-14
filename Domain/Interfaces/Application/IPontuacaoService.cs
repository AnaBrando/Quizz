using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Application
{
    public interface IPontuacaoService
    {
        void Add(PontuacaoDTO pontuacao);
        void Update(PerguntaDTO pontuacao);
        void Save();
    }
}
