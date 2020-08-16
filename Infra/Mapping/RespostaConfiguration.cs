﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Mapping
{
    public class RespostaConfiguration : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> entity)
        {
            entity.HasKey(x => x.RespostaId);

            entity.HasOne(d => d.Estudante)
                .WithMany(p => p.Resposta)
                .HasForeignKey(d => d.EstudanteId)
                .HasConstraintName("FK_Resposta_Estudante");
        }
    }
}