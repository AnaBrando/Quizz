﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Domain.Models 

{
    public class Resposta
    {
        public Resposta()
        {
            Pergunta = new HashSet<Pergunta>();
        }
        
        public int? RespostaId { get; set; }
        public string EstudanteChave { get; set; }
        public string Descricao { get; set; }
        public virtual Estudante Estudante { get; set; }
        public virtual ICollection<Pergunta> Pergunta { get; set; }
        public int EstudanteId{get;set;}
        public int PerguntaId { get; set; }
    }
}