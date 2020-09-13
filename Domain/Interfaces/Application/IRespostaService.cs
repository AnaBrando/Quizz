using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Application
{
    public interface IRespostaService
    {
        void Add(RespostaDTO pergunta);
        void Update(RespostaDTO pergunta);
        void Save();
        ICollection<RespostaDTO> GetAll(int quiizId);
        void Delete(int id);
        void GerarReposta(string estudanteId);
    }
}
