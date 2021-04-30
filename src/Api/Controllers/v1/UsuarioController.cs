using Application.Common.Models;
using Application.Mail.Commands.SendEmail;
using Application.Usuarios.Commands.CreateUsuario;
using Application.Usuarios.Queries.GetUsuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [ApiVersion("1")]
    public class UsuarioController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseApiResponse<PaginatedList<UsuarioDto>>>> Get([FromQuery] GetUsuariosQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseApiResponse<UsuarioDto>>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUsuarioByIdQuery { Id = id }));
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseApiResponse<UsuarioDto>>> Login(LoginUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<ActionResult<BaseApiResponse<int>>> Register(CreateUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("mail")]
        public async Task<IActionResult> Mail(SendEmailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
