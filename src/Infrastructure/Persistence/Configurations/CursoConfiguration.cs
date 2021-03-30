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
                .Property(x => x.TipoAsistencia)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Precio)
                .IsRequired();

            builder
                .Property(x => x.Calificacion)
                .IsRequired();

            builder
                .Property(x => x.UrlImagen)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasOne(x => x.Docente)
                .WithMany(x => x.Cursos)
                .HasForeignKey(x => x.DocenteId);

            builder
                .HasOne(x => x.Categoria)
                .WithMany(x => x.Cursos)
                .HasForeignKey(x => x.CategoriaId);

            builder
                .HasOne(b => b.Certificado)
                .WithOne(i => i.Curso)
                .HasForeignKey<Certificado>(b => b.CursoId);
        }
    }
}
