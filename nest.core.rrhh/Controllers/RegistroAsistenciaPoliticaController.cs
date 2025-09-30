using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticaServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para la gestión de políticas de registro de asistencia.
    /// Permite realizar operaciones CRUD para configurar los parámetros de tardanzas y horas extra.
    /// Requiere autorización para acceder a sus endpoints.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RegistroAsistenciaPoliticaController : ControllerBase
    {
        private readonly RegistroAsistenciaPoliticaService service;
        private readonly ILogger<RegistroAsistenciaPoliticaController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador.
        /// </summary>
        /// <param name="service">Servicio de aplicación para administrar las políticas de registro de asistencia.</param>
        /// <param name="logger">Logger para registrar eventos y errores del controlador.</param>
        public RegistroAsistenciaPoliticaController(RegistroAsistenciaPoliticaService service, ILogger<RegistroAsistenciaPoliticaController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las políticas de registro de asistencia configuradas.
        /// </summary>
        /// <returns>Lista de políticas disponibles.</returns>
        /// <response code="200">Devuelve la lista de políticas registradas.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<RegistroAsistenciaPolitica>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<RegistroAsistenciaPolitica>>> ObtenerTodos()
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

        /// <summary>
        /// Obtiene una política de registro de asistencia por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la política.</param>
        /// <returns>Política solicitada.</returns>
        /// <response code="200">Política encontrada.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RegistroAsistenciaPolitica), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaPolitica>> ObtenerPorId(long id)
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

        /// <summary>
        /// Crea una nueva política de registro de asistencia.
        /// </summary>
        /// <param name="registro">DTO con los datos de la política.</param>
        /// <returns>Política creada.</returns>
        /// <response code="200">Política creada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(RegistroAsistenciaPolitica), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaPolitica>> Agregar([FromBody] RegistroAsistenciaPoliticaCrearDto registro)
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

        /// <summary>
        /// Modifica una política de registro de asistencia existente.
        /// </summary>
        /// <param name="id">Identificador de la política a modificar.</param>
        /// <param name="registro">DTO con los datos actualizados.</param>
        /// <returns>Política actualizada.</returns>
        /// <response code="200">Política modificada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RegistroAsistenciaPolitica), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaPolitica>> Modificar(long id, [FromBody] RegistroAsistenciaPoliticaCrearDto registro)
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

        /// <summary>
        /// Elimina una política de registro de asistencia.
        /// </summary>
        /// <param name="id">Identificador de la política a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Política eliminada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
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
