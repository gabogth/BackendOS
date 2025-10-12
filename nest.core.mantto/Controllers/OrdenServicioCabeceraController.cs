using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.mantto.OrdenServicioCabeceraServices;
using nest.core.dominio;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.mantto.Controllers
{
    /// <summary>
    /// Controlador para la administración de órdenes de servicio cabecera.
    /// Proporciona operaciones CRUD básicas para gestionar la información principal de las órdenes de servicio.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrdenServicioCabeceraController : ControllerBase
    {
        private readonly OrdenServicioCabeceraService service;
        private readonly ILogger<OrdenServicioCabeceraController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de órdenes de servicio cabecera.
        /// </summary>
        /// <param name="service">Servicio de dominio para gestionar órdenes de servicio cabecera.</param>
        /// <param name="logger">Logger para el registro de eventos y errores.</param>
        public OrdenServicioCabeceraController(OrdenServicioCabeceraService service, ILogger<OrdenServicioCabeceraController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene la lista completa de órdenes de servicio cabecera.
        /// </summary>
        /// <returns>Listado de órdenes de servicio cabecera.</returns>
        /// <response code="200">Retorna la lista de órdenes de servicio cabecera.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrdenServicioCabecera>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<OrdenServicioCabecera>>> ObtenerTodos()
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
        /// Obtiene una orden de servicio cabecera por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la orden de servicio cabecera.</param>
        /// <returns>Orden de servicio cabecera encontrada.</returns>
        /// <response code="200">Orden de servicio cabecera encontrada.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> ObtenerPorId(long id)
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
        /// Crea una nueva orden de servicio cabecera.
        /// </summary>
        /// <param name="registro">Información de la orden de servicio cabecera a registrar.</param>
        /// <returns>Orden de servicio cabecera creada.</returns>
        /// <response code="200">Orden de servicio cabecera creada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> Agregar([FromBody] OrdenServicioCabeceraCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza la información de una orden de servicio cabecera existente.
        /// </summary>
        /// <param name="id">Identificador de la orden de servicio cabecera a modificar.</param>
        /// <param name="registro">Datos actualizados de la orden de servicio cabecera.</param>
        /// <returns>Orden de servicio cabecera modificada.</returns>
        /// <response code="200">Orden de servicio cabecera actualizada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> Modificar(long id, [FromBody] OrdenServicioCabeceraCrearDto registro)
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
        /// Elimina una orden de servicio cabecera existente.
        /// </summary>
        /// <param name="id">Identificador de la orden de servicio cabecera a eliminar.</param>
        /// <returns>Confirmación de la eliminación.</returns>
        /// <response code="200">Orden de servicio cabecera eliminada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
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
