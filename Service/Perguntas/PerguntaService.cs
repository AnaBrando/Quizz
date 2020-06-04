using Domain;
using Domain.Interfaces.Application;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Perguntas
{
    public class PerguntaService : IPerguntaService
    {
        public bool Acertou(int perguntaId, int respostaId)
        {
            throw new NotImplementedException();
        }

        public Pergunta ProximaPergunta(int id)
        {
            throw new NotImplementedException();
        }

        public Resposta RespostaCorreta(int perguntaId)
        {
            throw new NotImplementedException();
        }
    }
}
