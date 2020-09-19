using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Application
{
    public interface IRespostaService
    {
        int AddResposta(Resposta pergunta);
        void Update(Resposta pergunta);
        void Save();
        ICollection<Resposta> GetAll(int quiizId);
        void Delete(int id);
        int GerarReposta(string estudanteId, int perguntaId);
    }
}
