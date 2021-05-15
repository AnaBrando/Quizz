using Domain.DTO;
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
       public DbSet<EstudanteResposta> EstudanteResposta { get; set; }
        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Pontuacao> Pontuacao { get; set; }

        public DbSet<Professor> Professor { get; set; }
        public DbSet<Estudante> Estudante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         //=> options.UseSqlServer(@"Data Source=DESKTOP-OJVFABH\SQLEXPRESS;Initial Catalog=Quizz;Integrated Security=True;");
            => options.UseSqlServer(@"Server=tcp:127.0.0.1,1433;Database=Quizz;UID=SA;PWD=myPass123");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstudanteConfiguration());
            modelBuilder.ApplyConfiguration(new NivelConfiguration());
            modelBuilder.ApplyConfiguration(new PerguntaConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new QuizzConfiguration());
            modelBuilder.ApplyConfiguration(new RespostaConfiguration());
            modelBuilder.ApplyConfiguration(new RespostaConfiguration());
            modelBuilder.Entity<EstudanteResposta>()
     .HasKey(bc => new { bc.EstudanteId, bc.RespostaId });
           
            modelBuilder.Entity<EstudanteResposta>()
                .HasOne(bc => bc.Aluno)
                .WithMany(b => b.Respostas)
                .HasForeignKey(bc => bc.EstudanteId).IsRequired();
            modelBuilder.Entity<EstudanteResposta>()
                .HasOne(bc => bc.RespostaEstudante)
                .WithMany(c => c.EstudanteResposta)
                .HasForeignKey(bc => bc.RespostaId).IsRequired();

        }
    }


}

