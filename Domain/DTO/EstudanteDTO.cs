using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class EstudanteDTO
    {
        public EstudanteDTO()
        {
            Resposta = new HashSet<RespostaDTO>();
        }

        public int EstudanteId { get; set; }
        public string EstudanteSessao { get; set; }

            public string Nome { get; set; }
        public virtual ICollection<RespostaDTO> Resposta { get; set; }

                public decimal Pontuacao { get; set; }
    }
}
