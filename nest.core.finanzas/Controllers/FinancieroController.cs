using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.aplicacion.finanzas.Financiero.Queries;
using nest.core.dominio;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.finanzas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FinancieroController : ControllerBase
    {
        private readonly ISender sender;

        public FinancieroController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FinancieroCabecera>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<FinancieroCabecera>>> ObtenerTodos(CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerTodosQuery(), ct);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FinancieroCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<FinancieroCabecera>> ObtenerPorId([FromRoute] long id, CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerPorIdQuery(id), ct);
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FinancieroCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<FinancieroCabecera>> Agregar([FromBody] FinancieroCrearCommand command, CancellationToken ct)
        {
            var data = await sender.Send(command, ct);
            return Ok(data);
        }

        [HttpPost("detalle/{idCabecera}")]
        [ProducesResponseType(typeof(FinancieroDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<FinancieroDetalle>> AgregarDetalle([FromRoute] long idCabecera, [FromBody] FinancieroDetalleCrearCommand command, CancellationToken ct)
        {
            var cmd = command with { FinancieroCabeceraId = idCabecera };
            var data = await sender.Send(cmd, ct);
            return Ok(data);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FinancieroCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<FinancieroCabecera>> Modificar([FromRoute] long id, [FromBody] FinancieroModificarCommand command, CancellationToken ct)
        {
            var cmd = command with { Id = id };
            var data = await sender.Send(cmd, ct);
            return Ok(data);
        }

        [HttpPut("detalle/{id}")]
        [ProducesResponseType(typeof(FinancieroDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<FinancieroDetalle>> ModificarDetalle([FromRoute] long id, [FromBody] FinancieroDetalleModificarCommand command, CancellationToken ct)
        {
            var cmd = command with { Id = id };
            var data = await sender.Send(cmd, ct);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar([FromRoute] long id, CancellationToken ct)
        {
            await sender.Send(new FinancieroEliminarCommand(id), ct);
            return Ok(true);
        }

        [HttpDelete("detalle/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> EliminarDetalle([FromRoute] long id, CancellationToken ct)
        {
            await sender.Send(new FinancieroDetalleEliminarCommand(id), ct);
            return Ok(true);
        }
    }
}
