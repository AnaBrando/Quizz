﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Estudante", b =>
                {
                    b.Property<int>("EstudanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstudanteSessao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstudanteId");

                    b.ToTable("Estudante");
                });

            modelBuilder.Entity("Domain.Models.Nivel", b =>
                {
                    b.Property<int>("NivelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PontuacaoId")
                        .HasColumnType("int");

                    b.HasKey("NivelId");

                    b.HasIndex("PontuacaoId");

                    b.ToTable("Nivel");
                });

            modelBuilder.Entity("Domain.Models.Pergunta", b =>
                {
                    b.Property<int>("PerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NivelId")
                        .HasColumnType("int");

                    b.Property<string>("OpcaoA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpcaoB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpcaoC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpcaoCerta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpcaoD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuizzId")
                        .HasColumnType("int");

                    b.Property<int?>("RespostaId")
                        .HasColumnType("int");

                    b.HasKey("PerguntaId");

                    b.HasIndex("NivelId");

                    b.HasIndex("QuizzId");

                    b.HasIndex("RespostaId");

                    b.ToTable("Pergunta");
                });

            modelBuilder.Entity("Domain.Models.Pontuacao", b =>
                {
                    b.Property<int>("PontuacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("PontuacaoId");

                    b.ToTable("Pontuacao");
                });

            modelBuilder.Entity("Domain.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProfessorSessao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Domain.Models.Quizz", b =>
                {
                    b.Property<int>("QuizzId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessorSessao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizzId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Quizz");
                });

            modelBuilder.Entity("Domain.Models.Resposta", b =>
                {
                    b.Property<int>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstudanteId")
                        .HasColumnType("int");

                    b.HasKey("RespostaId");

                    b.HasIndex("EstudanteId");

                    b.ToTable("Resposta");
                });

            modelBuilder.Entity("Domain.Models.Nivel", b =>
                {
                    b.HasOne("Domain.Models.Pontuacao", "Pontuacao")
                        .WithMany("Nivel")
                        .HasForeignKey("PontuacaoId")
                        .HasConstraintName("FK_Nivel_Pontuacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Pergunta", b =>
                {
                    b.HasOne("Domain.Models.Nivel", "Nivel")
                        .WithMany("Pergunta")
                        .HasForeignKey("NivelId")
                        .HasConstraintName("FK_Pergunta_Nivel")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Models.Quizz", "Quizz")
                        .WithMany("Pergunta")
                        .HasForeignKey("QuizzId")
                        .HasConstraintName("FK_Pergunta_Quizz")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Models.Resposta", "Resposta")
                        .WithMany("Pergunta")
                        .HasForeignKey("RespostaId")
                        .HasConstraintName("FK_Pergunta_Resposta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.Quizz", b =>
                {
                    b.HasOne("Domain.Models.Professor", "Professor")
                        .WithMany("Quizz")
                        .HasForeignKey("ProfessorId")
                        .HasConstraintName("FK_Quizz_Professor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Resposta", b =>
                {
                    b.HasOne("Domain.Models.Estudante", "Estudante")
                        .WithMany("Resposta")
                        .HasForeignKey("EstudanteId")
                        .HasConstraintName("FK_Resposta_Estudante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
