using System.Collections.Generic;

namespace Domain.Models
{
    public class Categoria
    {
        public int Categoria_id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Quizz> Quizzs { get; set; }


    }
}
