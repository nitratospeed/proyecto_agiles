using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class CursoUsuarioConfiguration : IEntityTypeConfiguration<CursoUsuario>
    {
        public void Configure(EntityTypeBuilder<CursoUsuario> builder)
        {
            builder
                .HasKey(t => new { t.CursoId, t.UsuarioId });

            builder
                .HasOne(pt => pt.Curso)
                .WithMany(p => p.CursoUsuarios)
                .HasForeignKey(pt => pt.CursoId);

            builder
                .HasOne(pt => pt.Usuario)
                .WithMany(p => p.CursoUsuarios)
                .HasForeignKey(pt => pt.UsuarioId);
        }
    }
}
