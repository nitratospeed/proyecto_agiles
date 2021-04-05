using Application.Cursos.Commands.CreateCurso;
using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Cursos.Commands
{
    using static Testing;
    public class CreateCursoTests
    {
        [Test]
        public async Task ShouldCreate()
        {
            var command = new CreateCursoCommand
            {
                Nombre = "curso 55",
                Descripcion = "Become an expert in .NET Core with the latest technologies",
                TipoAsistencia = "Asíncrono",
                Precio = 84.99M,
                Calificacion = 4.95M,
                UrlImagen = "https://i.imgur.com/LtR5agQ.jpeg",
                DocenteId = 1,
                CategoriaId = 2
            };

            var result = await SendAsync(command);

            var item = await FindAsync<Curso>(result);

            item.Should().NotBeNull();

            item.Nombre.Should().Be(command.Nombre);
            item.Descripcion.Should().Be(command.Descripcion);
            item.TipoAsistencia.Should().Be(command.TipoAsistencia);
            item.Precio.Should().Be(command.Precio);
            item.Calificacion.Should().Be(command.Calificacion);
            item.UrlImagen.Should().Be(command.UrlImagen);
            item.DocenteId.Should().Be(command.DocenteId);
        }
    }
}
