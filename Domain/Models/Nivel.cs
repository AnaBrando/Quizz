﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Nivel
    {
        public Nivel()
        {
            Pergunta = new HashSet<Pergunta>();
        }

        public int NivelId { get; set; }
        public string Descricao { get; set; }
        public int PontuacaoId { get; set; }

        public virtual Pontuacao Pontuacao { get; set; }
        public virtual ICollection<Pergunta> Pergunta { get; set; }
    }
}