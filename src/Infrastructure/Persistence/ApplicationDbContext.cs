using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoContenido> CursoContenidos { get; set; }
        public DbSet<CursoContenidoDetalle> CursoContenidoDetalles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CursoUsuario> CursoUsuarios { get; set; }
        public DbSet<UsuarioTema> UsuarioTemas { get; set; }
        public DbSet<Tema> Temas { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
