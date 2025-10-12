using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.HorarioDetalleEventoServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para administrar los eventos asociados a los detalles de horario.
    /// Permite gestionar las marcas de entrada, salida y otras ventanas horarias.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HorarioDetalleEventoController : ControllerBase
    {
        private readonly HorarioDetalleEventoService service;
        private readonly ILogger<HorarioDetalleEventoController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador <see cref="HorarioDetalleEventoController"/>.
        /// </summary>
        /// <param name="service">Servicio de negocio para los eventos de detalle.</param>
        /// <param name="logger">Logger para seguimiento y auditoría.</param>
        public HorarioDetalleEventoController(HorarioDetalleEventoService service, ILogger<HorarioDetalleEventoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todos los eventos registrados.
        /// </summary>
        /// <returns>Listado de eventos de detalle.</returns>
        /// <response code="200">Devuelve la lista completa de eventos.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<HorarioDetalleEvento>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<HorarioDetalleEvento>>> ObtenerTodos()
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
        /// Obtiene un evento específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del evento.</param>
        /// <returns>Evento encontrado.</returns>
        /// <response code="200">Evento encontrado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HorarioDetalleEvento), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<HorarioDetalleEvento>> ObtenerPorId(long id)
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
        /// Obtiene los eventos registrados para un detalle de horario.
        /// </summary>
        /// <param name="horarioDetalleId">Identificador del detalle de horario.</param>
        /// <returns>Listado de eventos asociados.</returns>
        /// <response code="200">Devuelve los eventos filtrados por detalle.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("detalle/{horarioDetalleId}")]
        [ProducesResponseType(typeof(List<HorarioDetalleEvento>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<HorarioDetalleEvento>>> ObtenerPorHorarioDetalle(long horarioDetalleId)
        {
            try
            {
                var data = await service.ObtenerPorHorarioDetalleId(horarioDetalleId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Registra un nuevo evento dentro de un detalle de horario.
        /// </summary>
        /// <param name="horarioDetalleId">Identificador del detalle al que pertenece el evento.</param>
        /// <param name="registro">Datos del evento a registrar.</param>
        /// <returns>Evento creado.</returns>
        /// <response code="200">Evento registrado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost("detalle/{horarioDetalleId}")]
        [ProducesResponseType(typeof(HorarioDetalleEvento), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<HorarioDetalleEvento>> Agregar(long horarioDetalleId, [FromBody] HorarioDetalleEventoCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(horarioDetalleId, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Modifica un evento existente.
        /// </summary>
        /// <param name="id">Identificador del evento a modificar.</param>
        /// <param name="registro">Datos actualizados del evento.</param>
        /// <returns>Evento actualizado.</returns>
        /// <response code="200">Evento modificado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(HorarioDetalleEvento), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<HorarioDetalleEvento>> Modificar(long id, [FromBody] HorarioDetalleEventoCrearDto registro)
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
        /// Elimina un evento de horario.
        /// </summary>
        /// <param name="id">Identificador del evento a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Evento eliminado correctamente.</response>
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
