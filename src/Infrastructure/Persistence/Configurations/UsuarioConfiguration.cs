using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Nombres)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Apellidos)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Correo)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Contrasena)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
