using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceraServices;
using nest.core.dominio;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.mantto.Controllers
{
    /// <summary>
    /// Controlador para gestionar las cabeceras de orden de trabajo.
    /// Permite realizar operaciones CRUD y consultar por orden de servicio.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrdenTrabajoCabeceraController : ControllerBase
    {
        private readonly OrdenTrabajoCabeceraService service;
        private readonly ILogger<OrdenTrabajoCabeceraController> logger;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="OrdenTrabajoCabeceraController"/>.
        /// </summary>
        /// <param name="service">Servicio de cabeceras de orden de trabajo.</param>
        /// <param name="logger">Logger para registro de auditoría y errores.</param>
        public OrdenTrabajoCabeceraController(OrdenTrabajoCabeceraService service, ILogger<OrdenTrabajoCabeceraController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las cabeceras de orden de trabajo.
        /// </summary>
        /// <returns>Lista de cabeceras.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrdenTrabajoCabecera>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<OrdenTrabajoCabecera>>> ObtenerTodos()
        {
            try
            {
                var data = await service.ObtenerTodos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las cabeceras de orden de trabajo");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una cabecera de orden de trabajo por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la cabecera.</param>
        /// <returns>Cabecera encontrada.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrdenTrabajoCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoCabecera>> ObtenerPorId(long id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la cabecera {CabeceraId}", id);
                throw;
            }
        }

        /// <summary>
        /// Obtiene cabeceras de orden de trabajo asociadas a una orden de servicio.
        /// </summary>
        /// <param name="ordenServicioCabeceraId">Identificador de la orden de servicio.</param>
        /// <returns>Lista de cabeceras asociadas.</returns>
        [HttpGet("orden-servicio/{ordenServicioCabeceraId}")]
        [ProducesResponseType(typeof(List<OrdenTrabajoCabecera>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<OrdenTrabajoCabecera>>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId)
        {
            try
            {
                var data = await service.ObtenerPorOrdenServicio(ordenServicioCabeceraId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las cabeceras de la orden de servicio {OrdenServicioId}", ordenServicioCabeceraId);
                throw;
            }
        }

        /// <summary>
        /// Crea una nueva cabecera de orden de trabajo.
        /// </summary>
        /// <param name="registro">Datos de la cabecera a registrar.</param>
        /// <returns>Cabecera creada.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(OrdenTrabajoCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoCabecera>> Agregar([FromBody] OrdenTrabajoCabeceraCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear la cabecera de orden de trabajo");
                throw;
            }
        }

        /// <summary>
        /// Actualiza una cabecera de orden de trabajo existente.
        /// </summary>
        /// <param name="id">Identificador de la cabecera.</param>
        /// <param name="registro">Datos actualizados.</param>
        /// <returns>Cabecera modificada.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdenTrabajoCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoCabecera>> Modificar(long id, [FromBody] OrdenTrabajoCabeceraCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar la cabecera {CabeceraId}", id);
                throw;
            }
        }

        /// <summary>
        /// Elimina una cabecera de orden de trabajo.
        /// </summary>
        /// <param name="id">Identificador de la cabecera.</param>
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
                logger.LogError(ex, "Error al eliminar la cabecera {CabeceraId}", id);
                throw;
            }
        }
    }
}
