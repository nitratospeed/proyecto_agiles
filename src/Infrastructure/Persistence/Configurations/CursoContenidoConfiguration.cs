using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class CursoContenidoConfiguration : IEntityTypeConfiguration<CursoContenido>
    {
        public void Configure(EntityTypeBuilder<CursoContenido> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .HasOne(x => x.Curso)
                .WithMany(x => x.CursoContenidos)
                .HasForeignKey(x => x.CursoId);
        }
    }
}
