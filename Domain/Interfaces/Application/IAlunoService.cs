using Domain.DTO;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces.Application
{
    public interface IAlunoService
    {
      
        void Add(EstudanteDTO dto);

        EstudanteDTO GetbySession(string sessao);

        bool Acertou(int perguntaId,string resposta);

        double Pontuou(int perguntaId);

        List<Pergunta> GetPerguntas();
        bool PontuarAluno(string id, double pontuacao);
    }
}
