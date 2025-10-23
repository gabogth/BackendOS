using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.PersonaAdjuntos.Commands;
using nest.core.aplicacion.general.Features.PersonaAdjuntos.Queries;
using nest.core.dominio;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.general.Controllers
{
    /// <summary>
    /// Controlador para la gestión de adjuntos asociados a personas.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PersonaAdjuntoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<PersonaAdjuntoController> logger;

        public PersonaAdjuntoController(IMediator mediator, ILogger<PersonaAdjuntoController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PersonaAdjunto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<PersonaAdjunto>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetPersonaAdjuntosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonaAdjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonaAdjunto>> ObtenerPorId(long id)
        {
            try
            {
                var data = await mediator.Send(new GetPersonaAdjuntoByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("persona/{personaId}")]
        [ProducesResponseType(typeof(List<PersonaAdjunto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<PersonaAdjunto>>> ObtenerPorPersona(int personaId)
        {
            try
            {
                var data = await mediator.Send(new GetPersonaAdjuntosByPersonaQuery(personaId));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonaAdjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonaAdjunto>> Agregar([FromBody] CreatePersonaAdjuntoCommand command)
        {
            try
            {
                var data = await mediator.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonaAdjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonaAdjunto>> Modificar(long id, [FromBody] UpdatePersonaAdjuntoCommand command)
        {
            try
            {
                var data = await mediator.Send(command with { Id = id });
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(long id)
        {
            try
            {
                await mediator.Send(new DeletePersonaAdjuntoCommand(id));
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
