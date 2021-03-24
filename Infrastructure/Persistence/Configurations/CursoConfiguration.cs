using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(x => x.Categoria)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.SubCategoria)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.TipoAsistencia)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Precio)
                .IsRequired();

            builder
                .Property(x => x.BrindaCertificado)
                .IsRequired();

            builder
                .Property(x => x.CostoCertificado)
                .IsRequired();
        }
    }
}
