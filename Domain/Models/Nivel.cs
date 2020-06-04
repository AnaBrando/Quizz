using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Nivel
    {
        public int Nivel_id { get; set; }
        public string Descricao { get; set; }
        
        public decimal Pontuacao { get; set; }

        public virtual ICollection<Pergunta> Perguntas { get; set; }
    }
}
