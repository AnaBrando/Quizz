using System.Collections.Generic;
using Domain.Models;

namespace Domain.DTO
{
    public class RelatorioFinalObjectDTO
    {
        public virtual List<PerguntaDTO> Perguntas{get;set;}
        public List<RespostaDTO> Resposta { get; set; }

        public string NomeAluno { get; set; }

        public string NomeQuizz { get; set; }
    }
}