using Application.Common.Models;
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
    public class CursoController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CursoDto>>> Get([FromQuery] GetCursoQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCursoByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCursoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, UpdateCursoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCursoCommand { Id = id }));
        }
    }
}
