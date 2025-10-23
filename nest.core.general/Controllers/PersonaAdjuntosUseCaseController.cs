using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.PersonaUseCases;
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
        private readonly PersonaAdjuntosUseCase useCase;
        private readonly ILogger<PersonaAdjuntosUseCaseController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de personas con adjuntos.
        /// </summary>
        /// <param name="useCase">Caso de uso para operar sobre personas y sus adjuntos.</param>
        /// <param name="logger">Instancia del registrador.</param>
        public PersonaAdjuntosUseCaseController(PersonaAdjuntosUseCase useCase, ILogger<PersonaAdjuntosUseCaseController> logger)
        {
            this.useCase = useCase;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las personas junto con sus adjuntos registrados.
        /// </summary>
        /// <returns>Listado de personas.</returns>
        /// <response code="200">Listado recuperado correctamente.</response>
        /// <response code="400">Ocurrió un error al procesar la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Persona>>> ObtenerTodos()
        {
            try
            {
                var personas = await useCase.ObtenerTodos();
                return Ok(personas);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene una persona junto con sus adjuntos por identificador.
        /// </summary>
        /// <param name="id">Identificador de la persona.</param>
        /// <returns>Persona encontrada.</returns>
        /// <response code="200">Persona recuperada correctamente.</response>
        /// <response code="400">Ocurrió un error al procesar la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> ObtenerPorId(int id)
        {
            try
            {
                var persona = await useCase.ObtenerPorId(id);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crea una nueva persona y registra sus adjuntos asociados.
        /// </summary>
        /// <param name="registro">Información de la persona y sus adjuntos.</param>
        /// <returns>Persona creada.</returns>
        /// <response code="200">Persona creada correctamente.</response>
        /// <response code="400">Ocurrió un error al procesar la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> Agregar([FromBody] PersonaAdjuntosUseCaseCrearDto registro)
        {
            try
            {
                var persona = await useCase.Agregar(registro);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza una persona y sincroniza sus adjuntos.
        /// </summary>
        /// <param name="id">Identificador de la persona.</param>
        /// <param name="registro">Información actualizada de la persona y sus adjuntos.</param>
        /// <returns>Persona actualizada.</returns>
        /// <response code="200">Persona modificada correctamente.</response>
        /// <response code="400">Ocurrió un error al procesar la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Persona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Persona>> Modificar(int id, [FromBody] PersonaAdjuntosUseCaseCrearDto registro)
        {
            try
            {
                var persona = await useCase.Modificar(id, registro);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Elimina una persona y sus adjuntos relacionados.
        /// </summary>
        /// <param name="id">Identificador de la persona.</param>
        /// <response code="200">Persona eliminada correctamente.</response>
        /// <response code="400">Ocurrió un error al procesar la solicitud.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await useCase.Eliminar(id);
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
