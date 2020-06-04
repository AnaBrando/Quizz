using System.Collections.Generic;

namespace Domain.DTO
{
    public class NivelDTO
    {
        public int Nivel_id { get; set; }
        public string Descricao { get; set; }

        public decimal Pontuacao { get; set; }

        public virtual ICollection<PerguntaDTO> PerguntasDTO { get; set; }
    }
}
