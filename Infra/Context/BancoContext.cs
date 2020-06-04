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
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=NetworkLearning;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resposta>().HasOne(t => t.Pergunta).WithOne(t => t.Resposta).HasForeignKey<Pergunta>(b=>b.Pergunta_id);

            modelBuilder.Entity<Categoria>().HasKey(p => p.Categoria_id);

            modelBuilder.Entity<Nivel>().HasKey(p => p.Nivel_id);

            modelBuilder.Entity<Quizz>().HasKey(p => p.Quiz_id);

            modelBuilder.Entity<Resposta>().HasKey(p => p.Resposta_id);

            modelBuilder.Entity<Pergunta>().HasKey(p => p.Pergunta_id);
        }
    }
}
