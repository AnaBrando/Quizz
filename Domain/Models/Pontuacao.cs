﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Pontuacao
    {

        public int PontuacaoId { get; set; }
        public double Valor { get; set; }

        public int NivelId { get; set; }
        public virtual Nivel Nivel { get; set; }
    }
}