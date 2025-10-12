using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternoServices;
using nest.core.dominio;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.mantto.Controllers
{
    /// <summary>
    /// Controlador para la administración de órdenes de servicio de mantenimiento externo.
    /// Permite realizar operaciones CRUD básicas sobre las órdenes externas asociadas.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrdenServicioMantenimientoExternoController : ControllerBase
    {
        private readonly OrdenServicioMantenimientoExternoService service;
        private readonly ILogger<OrdenServicioMantenimientoExternoController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de mantenimiento externo.
        /// </summary>
        /// <param name="service">Servicio que gestiona las órdenes de servicio de mantenimiento externo.</param>
        /// <param name="logger">Logger para registrar eventos y errores.</param>
        public OrdenServicioMantenimientoExternoController(OrdenServicioMantenimientoExternoService service, ILogger<OrdenServicioMantenimientoExternoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las órdenes de servicio de mantenimiento externo registradas.
        /// </summary>
        /// <returns>Listado de órdenes de servicio de mantenimiento externo.</returns>
        /// <response code="200">Retorna la lista completa de órdenes externas.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrdenServicioMantenimientoExterno>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<OrdenServicioMantenimientoExterno>>> ObtenerTodos()
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
        /// Obtiene una orden de servicio de mantenimiento externo por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la orden de servicio de mantenimiento externo.</param>
        /// <returns>Orden de servicio de mantenimiento externo encontrada.</returns>
        /// <response code="200">Orden de servicio de mantenimiento externo encontrada.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrdenServicioMantenimientoExterno), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioMantenimientoExterno>> ObtenerPorId(long id)
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
        /// Crea una nueva orden de servicio de mantenimiento externo.
        /// </summary>
        /// <param name="registro">Información de la orden de servicio de mantenimiento externo a crear.</param>
        /// <returns>Orden de servicio de mantenimiento externo creada.</returns>
        /// <response code="200">Orden de servicio de mantenimiento externo creada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(OrdenServicioMantenimientoExterno), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioMantenimientoExterno>> Agregar([FromBody] OrdenServicioMantenimientoExternoCrearDto registro)
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
        /// Actualiza la información de una orden de servicio de mantenimiento externo existente.
        /// </summary>
        /// <param name="id">Identificador de la orden de servicio de mantenimiento externo a modificar.</param>
        /// <param name="registro">Datos actualizados de la orden externa.</param>
        /// <returns>Orden de servicio de mantenimiento externo modificada.</returns>
        /// <response code="200">Orden de servicio de mantenimiento externo actualizada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdenServicioMantenimientoExterno), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioMantenimientoExterno>> Modificar(long id, [FromBody] OrdenServicioMantenimientoExternoCrearDto registro)
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
        /// Elimina una orden de servicio de mantenimiento externo.
        /// </summary>
        /// <param name="id">Identificador de la orden de servicio de mantenimiento externo a eliminar.</param>
        /// <returns>Confirmación de la eliminación.</returns>
        /// <response code="200">Orden de servicio de mantenimiento externo eliminada correctamente.</response>
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
