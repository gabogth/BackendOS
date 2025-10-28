using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Personas.Commands;
using nest.core.aplicacion.general.Personas.Queries;
using nest.core.dominio;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.general.Controllers
{
    /// <summary>
    /// Controlador para la gestión de personas.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ISender sender;
        public PersonaController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Persona>>> ObtenerTodos([FromBody] ObtenerTodosQuery command, CancellationToken ct)
        {
            var entidad = await sender.Send(command);
            return Ok(entidad);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> ObtenerPorId([FromBody] ObtenerPorIdQuery command, CancellationToken ct)
        {
            var entidad = await sender.Send(command);
            return Ok(entidad);
        }
        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Persona>>> ObtenerActivos([FromBody] ObtenerActivosQuery command, CancellationToken ct)
        {
            var entidad = await sender.Send(command);
            return Ok(entidad);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> Agregar([FromBody] PersonaCrearCommand command, CancellationToken ct)
        {
            var entidad = await sender.Send(command);
            return Ok(entidad);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> Modificar([FromRoute] int id, [FromBody] PersonaModificarCommand command, CancellationToken ct)
        {
            var cmd = command with { Id = id };
            var entidad = await sender.Send(cmd);
            return Ok(entidad);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar([FromBody] PersonaEliminarCommand command, CancellationToken ct)
        {
            var entidad = await sender.Send(command);
            return Ok();
        }
    }
}
