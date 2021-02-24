using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class RespostaDTO
    {
        public RespostaDTO()
        {
            Pergunta = new HashSet<PerguntaDTO>();
        }

        public int RespostaId { get; set; }
        public int EstudanteId { get; set; }
        public bool Acertou { get;set;}
        public int Valor { get; set; }
        public string Descricao{get;set;}
        public virtual EstudanteDTO Estudante { get; set; }
        public virtual ICollection<PerguntaDTO> Pergunta { get; set; }
    }
}
