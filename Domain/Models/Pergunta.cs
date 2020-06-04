using Domain.Models;
using System;

namespace Domain
{
    public class Pergunta
    {
        public int Pergunta_id { get; set; }
        public string OpcaoA { get; set; }
        public string OpcaoB { get; set; }
        public string OpcaoC { get; set; }
        public string OpcaoD { get; set; }
        public string OpcaoCerta { get; set; }
        public int Quizz_id { get; set; }
        public virtual Quizz Quizz { get; set; }
        public virtual Resposta Resposta { get; set; }
        public int Resposta_id { get; set; }
        public string Descricao { get; set; }
    }
}
