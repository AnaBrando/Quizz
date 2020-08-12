using Domain;
using Domain.Models;
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
         => options.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=NetworkLearning;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Resposta>().HasKey(p => p.Resposta_id);
            modelBuilder.Entity<Resposta>().HasMany(x => x.Estudante_Reposta);
            modelBuilder.Entity<Resposta>().HasOne(t => t.Pergunta).WithOne(t => t.Resposta).HasForeignKey<Pergunta>(b => b.Pergunta_id);

            modelBuilder.Entity<Nivel>().HasOne(p => p.Pontuacao);
            modelBuilder.Entity<Nivel>().HasKey(p => p.Nivel_id);

         
            modelBuilder.Entity<Quizz>().HasKey(p => p.Quiz_id);
            modelBuilder.Entity<Quizz>().HasMany(p => p.Perguntas);


            modelBuilder.Entity<Estudante>().HasKey(p=>p.Estudante_ID);
            modelBuilder.Entity<Estudante>().HasMany(p => p.Resposta_Estudante);

            modelBuilder.Entity<Pontuacao>().HasKey(p => p.Pontuacao_ID);

            modelBuilder.Entity<Pergunta>().HasKey(p => p.Pergunta_id);
            modelBuilder.Entity<Pergunta>().HasOne(p => p.Nivel);
            modelBuilder.Entity<Pergunta>().HasOne(t => t.Resposta).WithOne(t => t.Pergunta).HasForeignKey<Resposta>(b => b.Pergunta_id);
           
            modelBuilder.Entity<Professor>().HasKey(p => p.Professor_ID);
        }
    }
}
