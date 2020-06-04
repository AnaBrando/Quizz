using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class QuizzDTO
    {
        public int Quiz_id { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataInclusão { get; set; }

        public virtual CategoriaDTO CategoriaDTO { get; set; }

        public int Categoria_id { get; set; }

        public virtual ICollection<QuizzDTO> QuizzsDTO { get; set; }
    }
}
