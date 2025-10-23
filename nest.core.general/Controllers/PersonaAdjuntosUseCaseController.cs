using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.PersonaAdjuntosUseCase.Commands;
using nest.core.aplicacion.general.Features.PersonaAdjuntosUseCase.Queries;
using nest.core.dominio;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.general.Controllers
{
    /// <summary>
    /// Controlador para gestionar personas junto con sus adjuntos asociados.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PersonaAdjuntosUseCaseController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<PersonaAdjuntosUseCaseController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de personas con adjuntos.
        /// </summary>
        public PersonaAdjuntosUseCaseController(IMediator mediator, ILogger<PersonaAdjuntosUseCaseController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Persona>>> ObtenerTodos()
        {
            try
            {
                var personas = await mediator.Send(new GetPersonasConAdjuntosQuery());
                return Ok(personas);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> ObtenerPorId(int id)
        {
            try
            {
                var persona = await mediator.Send(new GetPersonaConAdjuntosByIdQuery(id));
                return Ok(persona);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> Agregar([FromBody] CreatePersonaAdjuntosCommand command)
        {
            try
            {
                var persona = await mediator.Send(command);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> Modificar(int id, [FromBody] UpdatePersonaAdjuntosCommand command)
        {
            try
            {
                var persona = await mediator.Send(command with { Id = id });
                return Ok(persona);
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
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await mediator.Send(new DeletePersonaAdjuntosCommand(id));
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
