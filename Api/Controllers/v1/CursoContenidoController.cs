using Application.CursoContenidos.Queries.GetCursoContenidos;
using Application.Cursos.Commands.CreateCurso;
using Application.Cursos.Commands.DeleteCurso;
using Application.Cursos.Commands.UpdateCurso;
using Application.Cursos.Queries.GetCursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [ApiVersion("1")]
    public class CursoContenidoController : ApiControllerBase
    {
        [HttpGet("{cursoid}")]
        public async Task<IActionResult> GetById(int cursoid)
        {
            return Ok(await Mediator.Send(new GetCursoContenidoByIdQuery { Id = cursoid }));
        }
    }
}
