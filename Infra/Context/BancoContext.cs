using Domain.Models;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext()
        {
        }

        public BancoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Pontuacao> Pontuacao { get; set; }

        public DbSet<Professor> Professor { get; set; }
        public DbSet<Estudante> Estudante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer(@"Data Source = (LocalDB)\mssqllocaldb; Initial Catalog = NetworkLearning; Integrated Security = true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstudanteConfiguration());
            modelBuilder.ApplyConfiguration(new NivelConfiguration());
            modelBuilder.ApplyConfiguration(new PerguntaConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new QuizzConfiguration());
            modelBuilder.ApplyConfiguration(new RespostaConfiguration());

            ;
        }
    }


}

