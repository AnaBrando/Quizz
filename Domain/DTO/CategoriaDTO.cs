using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class CategoriaDTO
    {
        public int Categoria_id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<QuizzDTO> QuizzsDTO { get; set; }
    }
}
