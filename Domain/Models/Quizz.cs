using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Quizz
    {
        public int Quiz_id { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataInclusão { get; set; }

        public virtual Categoria Categoria { get; set; }

        public int Categoria_id { get; set; }

        

    }
}
