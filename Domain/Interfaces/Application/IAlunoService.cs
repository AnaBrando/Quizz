using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces.Application
{
    public interface IAlunoService
    {
      

        bool Acertou(int perguntaId,string resposta);

        double Pontuou(int perguntaId);

        List<Pergunta> GetPerguntas();
    }
}
