using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class PerguntaDTO
    {
        public PerguntaDTO()
        {
            this.niveis = new HashSet<Nivel>();
        }
        public int PerguntaId { get; set; }
        public int? NivelId { get; set; }
        public int? RespostaId { get; set; }
        public int QuizzId { get; set; }
        public string OpcaoA { get; set; }
        public string OpcaoB { get; set; }
        public string OpcaoC { get; set; }
        public string OpcaoD { get; set; }
        public string Descricao { get; set; }
        public string OpcaoCerta { get; set; }
        public virtual NivelDTO Nivel { get; set; }
        public virtual Quizz Quizz { get; set; }
        public virtual RespostaDTO Resposta { get; set; }
        public ICollection<Nivel> niveis { get; set; }
       
    }
}
