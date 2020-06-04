using Domain.Models;

namespace Domain.Interfaces.Application
{
    public interface IPerguntaService
    {
        Pergunta ProximaPergunta(int id);

        Resposta RespostaCorreta(int perguntaId);

        bool Acertou(int perguntaId, int respostaId);


    }
}
