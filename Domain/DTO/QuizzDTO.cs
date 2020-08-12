using Domain.Models;
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
        public string Professor_ID { get; set; }
        public virtual ProfessorDTO ProfessorDTO { get; set; }
        public virtual ICollection<PerguntaDTO> PerguntasDTO { get; set; }
    }
}
