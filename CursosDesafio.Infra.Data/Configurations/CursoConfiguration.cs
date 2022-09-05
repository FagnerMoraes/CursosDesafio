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
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();


            builder.Property(p => p.Tag).HasMaxLength(4).IsRequired();

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

        }
    }
}
