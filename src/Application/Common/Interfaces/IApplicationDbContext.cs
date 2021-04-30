using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Curso> Cursos { get; set; }
        DbSet<CursoContenido> CursoContenidos { get; set; }
        DbSet<CursoContenidoDetalle> CursoContenidoDetalles { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Certificado> Certificados { get; set; }
        DbSet<Docente> Docentes { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<CursoUsuario> CursoUsuarios { get; set; }
        DbSet<UsuarioTema> UsuarioTemas { get; set; }
        DbSet<Tema> Temas { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
