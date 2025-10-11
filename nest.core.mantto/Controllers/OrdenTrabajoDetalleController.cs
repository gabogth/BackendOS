using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleServices;
using nest.core.dominio;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.mantto.Controllers
{
    /// <summary>
    /// Controlador para la gestión de los detalles de orden de trabajo.
    /// Permite CRUD y consultas por cabecera.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrdenTrabajoDetalleController : ControllerBase
    {
        private readonly OrdenTrabajoDetalleService service;
        private readonly ILogger<OrdenTrabajoDetalleController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador.
        /// </summary>
        /// <param name="service">Servicio de detalles de orden de trabajo.</param>
        /// <param name="logger">Logger para registrar eventos.</param>
        public OrdenTrabajoDetalleController(OrdenTrabajoDetalleService service, ILogger<OrdenTrabajoDetalleController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene un detalle de orden de trabajo por su identificador.
        /// </summary>
        /// <param name="id">Identificador del detalle.</param>
        /// <returns>Detalle solicitado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrdenTrabajoDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoDetalle>> ObtenerPorId(long id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el detalle {DetalleId}", id);
                throw;
            }
        }

        /// <summary>
        /// Obtiene los detalles de una cabecera de orden de trabajo específica.
        /// </summary>
        /// <param name="ordenTrabajoCabeceraId">Identificador de la cabecera.</param>
        /// <returns>Lista de detalles asociados.</returns>
        [HttpGet("cabecera/{ordenTrabajoCabeceraId}")]
        [ProducesResponseType(typeof(List<OrdenTrabajoDetalle>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<OrdenTrabajoDetalle>>> ObtenerPorCabecera(long ordenTrabajoCabeceraId)
        {
            try
            {
                var data = await service.ObtenerPorCabecera(ordenTrabajoCabeceraId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los detalles de la cabecera {CabeceraId}", ordenTrabajoCabeceraId);
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo detalle de orden de trabajo.
        /// </summary>
        /// <param name="registro">Datos del detalle a registrar.</param>
        /// <returns>Detalle creado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(OrdenTrabajoDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoDetalle>> Agregar([FromBody] OrdenTrabajoDetalleCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear el detalle de orden de trabajo");
                throw;
            }
        }

        /// <summary>
        /// Modifica un detalle de orden de trabajo existente.
        /// </summary>
        /// <param name="id">Identificador del detalle.</param>
        /// <param name="registro">Datos actualizados.</param>
        /// <returns>Detalle modificado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdenTrabajoDetalle), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoDetalle>> Modificar(long id, [FromBody] OrdenTrabajoDetalleCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar el detalle {DetalleId}", id);
                throw;
            }
        }

        /// <summary>
        /// Elimina un detalle de orden de trabajo.
        /// </summary>
        /// <param name="id">Identificador del detalle.</param>
        /// <returns>Resultado de la operación.</returns>
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
                logger.LogError(ex, "Error al eliminar el detalle {DetalleId}", id);
                throw;
            }
        }
    }
}
