using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.HorarioDetalleServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para administrar los detalles de horarios.
    /// Permite gestionar la configuración diaria de un horario sin depender de la cabecera.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HorarioDetalleController : ControllerBase
    {
        private readonly HorarioDetalleService service;
        private readonly ILogger<HorarioDetalleController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador <see cref="HorarioDetalleController"/>.
        /// </summary>
        /// <param name="service">Servicio de negocio para los detalles de horario.</param>
        /// <param name="logger">Logger para registrar eventos y errores.</param>
        public HorarioDetalleController(HorarioDetalleService service, ILogger<HorarioDetalleController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todos los detalles de horario registrados.
        /// </summary>
        /// <returns>Listado de detalles de horario.</returns>
        /// <response code="200">Devuelve la lista completa de detalles.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<HorarioDetalle>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<HorarioDetalle>>> ObtenerTodos()
        {
            try
            {
                var data = await service.ObtenerTodos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un detalle de horario por su identificador.
        /// </summary>
        /// <param name="id">Identificador del detalle de horario.</param>
        /// <returns>Detalle encontrado.</returns>
        /// <response code="200">Detalle encontrado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HorarioDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<HorarioDetalle>> ObtenerPorId(long id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene los detalles registrados para una cabecera de horario específica.
        /// </summary>
        /// <param name="horarioCabeceraId">Identificador de la cabecera de horario.</param>
        /// <returns>Listado de detalles asociados a la cabecera.</returns>
        /// <response code="200">Devuelve los detalles filtrados por cabecera.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("cabecera/{horarioCabeceraId}")]
        [ProducesResponseType(typeof(List<HorarioDetalle>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<HorarioDetalle>>> ObtenerPorCabecera(int horarioCabeceraId)
        {
            try
            {
                var data = await service.ObtenerPorCabeceraId(horarioCabeceraId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Registra un nuevo detalle de horario dentro de una cabecera.
        /// </summary>
        /// <param name="horarioCabeceraId">Identificador de la cabecera a la que pertenecerá el detalle.</param>
        /// <param name="registro">Datos del detalle a registrar.</param>
        /// <returns>Detalle creado.</returns>
        /// <response code="200">Detalle registrado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost("cabecera/{horarioCabeceraId}")]
        [ProducesResponseType(typeof(HorarioDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<HorarioDetalle>> Agregar(int horarioCabeceraId, [FromBody] HorarioDetalleCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(horarioCabeceraId, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza la configuración de un detalle de horario.
        /// </summary>
        /// <param name="id">Identificador del detalle a modificar.</param>
        /// <param name="registro">Datos actualizados del detalle.</param>
        /// <returns>Detalle actualizado.</returns>
        /// <response code="200">Detalle modificado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(HorarioDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<HorarioDetalle>> Modificar(long id, [FromBody] HorarioDetalleCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Elimina un detalle de horario.
        /// </summary>
        /// <param name="id">Identificador del detalle a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Detalle eliminado correctamente.</response>
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
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
