using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.PersonaAdjuntoServices;
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
        private readonly PersonaAdjuntoService service;
        private readonly ILogger<PersonaAdjuntoController> logger;

        public PersonaAdjuntoController(PersonaAdjuntoService service, ILogger<PersonaAdjuntoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PersonaAdjunto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<PersonaAdjunto>>> ObtenerTodos()
        {
            try
            {
                var data = await service.ObtenerTodos();
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
                var data = await service.ObtenerPorId(id);
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
                var data = await service.ObtenerPorPersona(personaId);
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
        public async Task<ActionResult<PersonaAdjunto>> Agregar([FromBody] PersonaAdjuntoCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
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
        public async Task<ActionResult<PersonaAdjunto>> Modificar(long id, [FromBody] PersonaAdjuntoCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
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
                await service.Eliminar(id);
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
