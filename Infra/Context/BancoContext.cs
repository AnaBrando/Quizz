using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Context
{
    public class BancoContext : DbContext
    {
        
        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        
    }
}
