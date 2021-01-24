using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class EstudanteResposta
    {
        public int EstudanteId { get; set; }

        public int RespostaId { get; set; }

        public virtual Resposta RespostaEstudante { get; set; }

        public virtual Estudante Aluno { get; set; }
    }
}
