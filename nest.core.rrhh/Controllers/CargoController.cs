using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.aplicacion.rrhh.Cargos.Queries;
using nest.core.dominio;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.rrhh.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ISender sender;

        public CargoController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cargo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Cargo>>> ObtenerTodos(CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerCargosQuery(), ct);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cargo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Cargo>> ObtenerPorId(int id, CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerCargoPorIdQuery(id), ct);
            return Ok(data);
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<Cargo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Cargo>>> ObtenerActivos(CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerCargosActivosQuery(), ct);
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cargo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Cargo>> Agregar([FromBody] CargoCrearCommand command, CancellationToken ct)
        {
            var data = await sender.Send(command, ct);
            return Ok(data);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cargo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Cargo>> Modificar(int id, [FromBody] CargoModificarCommand command, CancellationToken ct)
        {
            var data = await sender.Send(command with { Id = id }, ct);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(int id, CancellationToken ct)
        {
            await sender.Send(new CargoEliminarCommand(id), ct);
            return Ok();
        }
    }
}
