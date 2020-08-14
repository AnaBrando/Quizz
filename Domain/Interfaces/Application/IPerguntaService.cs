using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IPerguntaService
    {
        void Add(PerguntaDTO pergunta);
        void Update(PerguntaDTO pergunta);
        void Save();
        Task<PerguntaDTO> QuizzIT(int id);
    }
}
