using Application.Categorias.Queries.GetCategorias;
using Application.Docentes.Queries.GetDocentes;
using Application.Sumarizados.Queries.GetSumarizados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [ApiVersion("1")]
    public class SumarizadoController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetSumarizadosQuery()));
        }
    }
}
