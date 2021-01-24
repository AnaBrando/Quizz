using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Application
{
    public interface IRespostaService
    {
        void Update(Resposta pergunta);
        void Save();
        ICollection<Resposta> GetAll(int quiizId);
        void Delete(int id);
        RelatorioFinalObjectDTO GerarDadosRelatorio(int quizzId,int alunoId,string sessaoNome);
       void PDF();
        int GerarReposta(int estudanteId, int perguntaId,bool acertou);
    }
}
