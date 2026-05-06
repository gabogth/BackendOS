using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Provincias.Commands;
using nest.core.aplicacion.general.Provincias.Queries;
using nest.core.dominio;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.general.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProvinciaController : ControllerBase
    {
        private readonly ISender sender;

        public ProvinciaController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Provincia>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Provincia>>> ObtenerTodos(CancellationToken cancellationToken)
        {
            var data = await sender.Send(new ObtenerTodosQuery(), cancellationToken);
            return Ok(data);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Provincia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Provincia>> ObtenerPorId([FromRoute] int id, CancellationToken cancellationToken)
        {
            var data = await sender.Send(new ObtenerPorIdQuery(id), cancellationToken);
            return Ok(data);
        }
        [HttpPost("filter")]
        [ProducesResponseType(typeof(LoadResult), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<LoadResult>> ObtenerPorFiltro([FromBody] DataSourceLoadOptionsBase options, CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerPorFiltroQuery(options), ct);
            return Ok(data);
        }

        [HttpPost("filter_activos")]
        [ProducesResponseType(typeof(LoadResult), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<LoadResult>> ObtenerPorFiltroActivos([FromBody] DataSourceLoadOptionsBase options, CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerPorFiltroActivosQuery(options), ct);
            return Ok(data);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Provincia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Provincia>> Agregar([FromBody] ProvinciaCrearCommand command, CancellationToken cancellationToken)
        {
            var data = await sender.Send(command, cancellationToken);
            return Ok(data);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Provincia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Provincia>> Modificar([FromRoute] int id, [FromBody] ProvinciaModificarCommand command, CancellationToken cancellationToken)
        {
            var cmd = command with { Id = id };
            var data = await sender.Send(cmd, cancellationToken);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar([FromRoute] int id, CancellationToken cancellationToken)
        {
            await sender.Send(new ProvinciaEliminarCommand(id), cancellationToken);
            return Ok(true);
        }
    }
}
