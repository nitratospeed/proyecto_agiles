using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class CursoContenidoDetalleConfiguration : IEntityTypeConfiguration<CursoContenidoDetalle>
    {
        public void Configure(EntityTypeBuilder<CursoContenidoDetalle> builder)
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
                .HasOne(x => x.CursoContenido)
                .WithMany(x => x.CursoContenidoDetalles)
                .HasForeignKey(x => x.CursoContenidoId);
        }
    }
}
