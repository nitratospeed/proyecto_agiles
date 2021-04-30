using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class UsuarioTemaConfiguration : IEntityTypeConfiguration<UsuarioTema>
    {
        public void Configure(EntityTypeBuilder<UsuarioTema> builder)
        {
            builder
                .HasKey(t => new { t.TemaId, t.UsuarioId });

            builder
                .HasOne(pt => pt.Tema)
                .WithMany(p => p.UsuarioTemas)
                .HasForeignKey(pt => pt.TemaId);

            builder
                .HasOne(pt => pt.Usuario)
                .WithMany(p => p.UsuarioTemas)
                .HasForeignKey(pt => pt.UsuarioId);
        }
    }
}
