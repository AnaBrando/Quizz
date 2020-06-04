﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20200604165445_primeiro")]
    partial class primeiro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Categoria", b =>
                {
                    b.Property<int>("Categoria_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoria_id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Domain.Models.Nivel", b =>
                {
                    b.Property<int>("Nivel_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pontuacao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Nivel_id");

                    b.ToTable("Nivel");
                });

            modelBuilder.Entity("Domain.Models.Quizz", b =>
                {
                    b.Property<int>("Quiz_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Categoria_id")
                        .HasColumnType("int");

                    b.Property<int?>("Categoria_id1")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInclusão")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Quiz_id");

                    b.HasIndex("Categoria_id1");

                    b.ToTable("Quizz");
                });

            modelBuilder.Entity("Domain.Models.Resposta", b =>
                {
                    b.Property<int>("Resposta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Pergunta_id")
                        .HasColumnType("int");

                    b.Property<string>("RespostaCerta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Resposta_id");

                    b.ToTable("Resposta");
                });

            modelBuilder.Entity("Domain.Pergunta", b =>
                {
                    b.Property<int>("Pergunta_id")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nivel_id")
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

                    b.Property<int?>("QuizzQuiz_id")
                        .HasColumnType("int");

                    b.Property<int>("Quizz_id")
                        .HasColumnType("int");

                    b.Property<int>("Resposta_id")
                        .HasColumnType("int");

                    b.HasKey("Pergunta_id");

                    b.HasIndex("Nivel_id");

                    b.HasIndex("QuizzQuiz_id");

                    b.ToTable("Pergunta");
                });

            modelBuilder.Entity("Domain.Models.Quizz", b =>
                {
                    b.HasOne("Domain.Models.Categoria", "Categoria")
                        .WithMany("Quizzs")
                        .HasForeignKey("Categoria_id1");
                });

            modelBuilder.Entity("Domain.Pergunta", b =>
                {
                    b.HasOne("Domain.Models.Nivel", null)
                        .WithMany("Perguntas")
                        .HasForeignKey("Nivel_id");

                    b.HasOne("Domain.Models.Resposta", "Resposta")
                        .WithOne("Pergunta")
                        .HasForeignKey("Domain.Pergunta", "Pergunta_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Quizz", "Quizz")
                        .WithMany()
                        .HasForeignKey("QuizzQuiz_id");
                });
#pragma warning restore 612, 618
        }
    }
}
