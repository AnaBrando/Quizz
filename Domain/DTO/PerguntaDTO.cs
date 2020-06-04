using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class PerguntaDTO
    {
        public int Pergunta_id { get; set; }
        public string OpcaoA { get; set; }
        public string OpcaoB { get; set; }
        public string OpcaoC { get; set; }
        public string OpcaoD { get; set; }
        public string OpcaoCerta { get; set; }
        public int Quizz_id { get; set; }
        public virtual QuizzDTO QuizzDTO { get; set; }
    }
}
