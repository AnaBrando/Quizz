using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class PerguntaDTO
    {
        public PerguntaDTO()
        {
            this.niveis = new HashSet<NivelDTO>();
        }

        public int Pergunta_id { get; set; }
        public ICollection<NivelDTO> niveis { get; set; }
        public string Descricao { get; set; }
        public string OpcaoA { get; set; }
        public string OpcaoB { get; set; }
        public string OpcaoC { get; set; }
        public string OpcaoD { get; set; }
        public virtual RespostaDTO RespostaDTO { get; set; }
        public int Quizz_id { get; set; }
        public virtual NivelDTO NivelDTO { get; set; }

        public int Nivel_ID { get; set; }
        public string Resposta_id { get; set; }
        public virtual QuizzDTO QuizzDTO { get; set; }
    }
}
