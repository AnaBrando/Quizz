using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class RespostaDTO
    {
        public int Resposta_id { get; set; }
        public string RespostaCerta { get; set; }

        public int Pergunta_id { get; set; }
        public virtual PerguntaDTO PerguntaDTO { get; set; }
    }
}
