using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Personas.Commands.CreatePersona;
using nest.core.aplicacion.general.Personas.Commands.DeletePersona;
using nest.core.aplicacion.general.Personas.Commands.UpdatePersona;
using nest.core.aplicacion.general.Personas.Dtos;
using nest.core.aplicacion.general.Personas.Queries.GetPersonaById;
using nest.core.aplicacion.general.Personas.Queries.GetPersonas;
using nest.core.aplicacion.general.Personas.Queries.GetPersonasActivas;
using nest.core.dominio;

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
        private readonly IMediator mediator;
        private readonly ILogger<PersonaController> logger;

        public PersonaController(IMediator mediator, ILogger<PersonaController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PersonaResponseDto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<PersonaResponseDto>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetPersonasQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonaResponseDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonaResponseDto?>> ObtenerPorId(int id)
        {
            try
            {
                var data = await mediator.Send(new GetPersonaByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<PersonaResponseDto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<PersonaResponseDto>>> ObtenerActivos()
        {
            try
            {
                var data = await mediator.Send(new GetPersonasActivasQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonaResponseDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonaResponseDto>> Agregar([FromBody] PersonaCreateDto registro)
        {
            try
            {
                var data = await mediator.Send(new CreatePersonaCommand(registro));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonaResponseDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonaResponseDto>> Modificar(int id, [FromBody] PersonaCreateDto registro)
        {
            try
            {
                var data = await mediator.Send(new UpdatePersonaCommand(id, registro));
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
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await mediator.Send(new DeletePersonaCommand(id));
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
