using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.dominio;
using nest.core.aplicacion.logistica;
using nest.core.dominio.Logistica.OrdenServicio;

namespace nest.core.logistica.Controllers
{
    /// <summary>
    /// Controlador para ordenes de servicio de mantenimiento externo.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrdenServicioMantenimientoExternoController : ControllerBase
    {
        private readonly OrdenServicioMantenimientoExternoService service;
        private readonly ILogger<OrdenServicioMantenimientoExternoController> logger;
        public OrdenServicioMantenimientoExternoController(OrdenServicioMantenimientoExternoService service, ILogger<OrdenServicioMantenimientoExternoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>Obtiene todas las ordenes de mantenimiento externo.</summary>
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
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        /// <summary>Obtiene una orden de mantenimiento externo por id.</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> ObtenerPorId(int id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        /// <summary>Agrega una nueva orden de mantenimiento externo.</summary>
        [HttpPost]
        [ProducesResponseType(typeof(OrdenServicioMantenimientoExterno), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioMantenimientoExterno>> Agregar([FromBody] OrdenServicioMantenimientoExternoCrearDto entry)
        {
            try
            {
                var data = await service.Agregar(entry);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        /// <summary>Modifica una orden de mantenimiento externo.</summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdenServicioCabecera), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenServicioCabecera>> Modificar(int id, [FromBody] OrdenServicioMantenimientoExternoCrearDto entry)
        {
            try
            {
                var data = await service.Modificar(id, entry);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        /// <summary>Elimina una orden de mantenimiento externo.</summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await service.Eliminar(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }
    }
}
