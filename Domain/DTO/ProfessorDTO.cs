using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ProfessorDTO
    {
        public ProfessorDTO()
        {
            Quizz = new HashSet<QuizzDTO>();
        }

        public int ProfessorId { get; set; }
        public string ProfessorSessao { get; set; }

        public virtual ICollection<QuizzDTO> Quizz { get; set; }
    }
}

