﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Resposta
    {
        public int Resposta_id { get; set; }
        public string RespostaCerta { get; set; }
        public int Pergunta_id { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public int Estudante_ID { get; set; }
        public virtual ICollection<Estudante> Estudante_Reposta { get; set; }
    }
}
