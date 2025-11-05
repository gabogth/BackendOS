using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;
using nest.core.aplicacion.mantto.OrdenServicio.Queries;
using nest.core.dominio;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.mantto.Controllers
{
    /// <summary>
    /// Controlador para la administración integral de órdenes de servicio de mantenimiento externo.
    /// Permite gestionar la cabecera de la orden junto a la información específica del mantenimiento externo.
    /// </summary>
    [Authorize]
    [Route("{controller}")]
    [ApiController]
    public class MantenimientoExternoController : ControllerBase
    {
        private readonly ISender sender;
        private readonly ILogger<MantenimientoExternoController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de mantenimiento externo compuesto.
        /// </summary>
        /// <param name="sender">Mediador utilizado para orquestar las operaciones de mantenimiento externo.</param>
        /// <param name="logger">Instancia de <see cref="ILogger"/> para el registro de eventos.</param>
        public MantenimientoExternoController(ISender sender, ILogger<MantenimientoExternoController> logger)
        {
            this.sender = sender;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las órdenes de servicio de mantenimiento externo con su información relacionada.
        /// </summary>
        /// <returns>Listado de órdenes de servicio de mantenimiento externo.</returns>
        /// <response code="200">Lista completa de órdenes externas encontradas.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrdenServicioCabecera>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<OrdenServicioCabecera>>> ObtenerTodos()
        {
            try
            {
                var data = await sender.Send(new ObtenerOrdenServicioMantenimientoExternoTodosQuery());
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
        /// <param name="id">Identificador de la orden de servicio.</param>
        /// <returns>Orden de servicio de mantenimiento externo encontrada.</returns>
        /// <response code="200">Orden de servicio de mantenimiento externo encontrada.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> ObtenerPorId([FromRoute] long id)
        {
            try
            {
                var data = await sender.Send(new ObtenerOrdenServicioMantenimientoExternoPorIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crea una nueva orden de servicio de mantenimiento externo con cabecera e información externa.
        /// </summary>
        /// <param name="command">Datos de la orden de servicio y del mantenimiento externo.</param>
        /// <returns>Orden de servicio de mantenimiento externo creada.</returns>
        /// <response code="200">Orden de servicio creada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> Agregar([FromBody] OrdenServicioMantenimientoExternoRegistrarCommand command)
        {
            try
            {
                var data = await sender.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza una orden de servicio de mantenimiento externo existente.
        /// </summary>
        /// <param name="id">Identificador de la orden de servicio a modificar.</param>
        /// <param name="command">Datos actualizados de la cabecera y del mantenimiento externo.</param>
        /// <returns>Orden de servicio de mantenimiento externo modificada.</returns>
        /// <response code="200">Orden de servicio modificada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> Modificar([FromRoute] long id, [FromBody] OrdenServicioMantenimientoExternoActualizarCommand command)
        {
            try
            {
                var cmd = command with { Id = id };
                var data = await sender.Send(cmd);
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
        /// <param name="id">Identificador de la orden de servicio a eliminar.</param>
        /// <returns>Confirmación de la eliminación.</returns>
        /// <response code="200">Orden de servicio eliminada correctamente.</response>
        /// <response code="400">Se produjo un error en la solicitud.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar([FromRoute] long id)
        {
            try
            {
                await sender.Send(new OrdenServicioMantenimientoExternoEliminarCommand(id));
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
