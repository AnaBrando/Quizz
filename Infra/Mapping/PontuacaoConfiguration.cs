using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
         public class PontuacaoConfiguration : IEntityTypeConfiguration<Pontuacao>
        {
            public void Configure(EntityTypeBuilder<Pontuacao> entity)
            {
                    entity.HasKey(x=>x.PontuacaoId);
                   /* entity.HasOne<Nivel>()
                          .WithOne(x => x.Pontuacao).HasForeignKey<Nivel>(x => x.PontuacaoId);*/
                        

            }
        }
}
