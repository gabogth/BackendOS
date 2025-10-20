using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajoServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para la administración de la relación entre registros de asistencia y órdenes de trabajo.
    /// Permite realizar operaciones CRUD básicas sobre los vínculos creados en el sistema.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RegistroAsistenciaOrdenTrabajoController : ControllerBase
    {
        private readonly RegistroAsistenciaOrdenTrabajoService service;
        private readonly ILogger<RegistroAsistenciaOrdenTrabajoController> logger;

        /// <summary>
        /// Inicializa el controlador de RegistroAsistenciaOrdenTrabajo.
        /// </summary>
        /// <param name="service">Servicio de aplicación encargado de la lógica de negocio.</param>
        /// <param name="logger">Logger para registrar la actividad del controlador.</param>
        public RegistroAsistenciaOrdenTrabajoController(RegistroAsistenciaOrdenTrabajoService service, ILogger<RegistroAsistenciaOrdenTrabajoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todos los registros de asistencia vinculados a órdenes de trabajo.
        /// </summary>
        /// <returns>Listado de relaciones registradas.</returns>
        /// <response code="200">Relaciones recuperadas correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<RegistroAsistenciaOrdenTrabajo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<RegistroAsistenciaOrdenTrabajo>>> ObtenerTodos()
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
        /// Obtiene un registro de asistencia asociado a una orden de trabajo por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro de asistencia.</param>
        /// <returns>Relación encontrada.</returns>
        /// <response code="200">Relación encontrada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RegistroAsistenciaOrdenTrabajo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaOrdenTrabajo>> ObtenerPorId(long id)
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
        /// Crea una relación entre un registro de asistencia y una orden de trabajo.
        /// </summary>
        /// <param name="registro">Datos de la relación a crear.</param>
        /// <returns>Relación creada.</returns>
        /// <response code="200">Relación creada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(RegistroAsistenciaOrdenTrabajo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaOrdenTrabajo>> Agregar([FromBody] RegistroAsistenciaOrdenTrabajoCrearDto registro)
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
        /// Actualiza una relación existente entre un registro de asistencia y una orden de trabajo.
        /// </summary>
        /// <param name="id">Identificador del registro de asistencia asociado.</param>
        /// <param name="registro">Datos actualizados de la relación.</param>
        /// <returns>Relación actualizada.</returns>
        /// <response code="200">Relación actualizada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RegistroAsistenciaOrdenTrabajo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaOrdenTrabajo>> Modificar(long id, [FromBody] RegistroAsistenciaOrdenTrabajoCrearDto registro)
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
        /// Elimina la relación entre un registro de asistencia y una orden de trabajo.
        /// </summary>
        /// <param name="id">Identificador del registro de asistencia asociado.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Relación eliminada correctamente.</response>
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
