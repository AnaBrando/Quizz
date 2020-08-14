using System.Collections.Generic;

namespace Domain.DTO
{
    public class NivelDTO
    {
        public int Nivel_id { get; set; }
        public string Descricao { get; set; }

        public virtual PontuacaoDTO PontuacaoDTO { get; set; }
        public int Pontuacao_ID { get; set; }

    }
}
