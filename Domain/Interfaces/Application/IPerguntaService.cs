using Domain.DTO;
using Domain.Models;
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
        
        void Delete(int id);
        PerguntaDTO getById(int id);
        Task<Pergunta> QuizzIT(int id);

        List<Pergunta> PerguntasByQuizzId(int id);
    }
}
