using CursosDesafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosDesafio.Infra.Data.Configurations
{
    public class AulaConfiguration : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.ToTable("Aula");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();

        
        builder.Property(p => p.TituloDaAula)
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(p => p.DescricaoDaAula)
            .HasColumnType("varchar(300)")
            .IsRequired();
  
        builder.Property(p => p.UrlVideoDaAula)
             .HasColumnType("varchar(300)")
             .IsRequired();
  

        

    }
}
}
