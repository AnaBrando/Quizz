using System.Collections.Generic;

namespace Domain.Models
{
    public class Nivel
    {
        public int Nivel_id { get; set; }
        public string Descricao { get; set; }
        public virtual Pontuacao Pontuacao { get; set; }
        public int Pontuacao_ID { get; set; }
    }
}
