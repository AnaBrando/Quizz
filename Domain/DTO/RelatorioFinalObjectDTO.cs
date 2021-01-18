using System.Collections.Generic;
using Domain.Models;

namespace Domain.DTO
{
    public class RelatorioFinalObjectDTO
    {
        public virtual List<Pergunta> Perguntas{get;set;}
        public virtual RelatorioFinalDTO Relatorio{get;set;}
        public int quiizId {get;set;}
    }
}