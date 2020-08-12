using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Estudante
    {
        public int Estudante_ID { get; set; }

 

        public virtual ICollection<Resposta> Resposta_Estudante { get; set; }

       
    }
}
