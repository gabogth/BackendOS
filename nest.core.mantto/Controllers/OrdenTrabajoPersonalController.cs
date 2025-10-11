using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonalServices;
using nest.core.dominio;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.mantto.Controllers
{
    /// <summary>
    /// Controlador para gestionar el personal asociado a las órdenes de trabajo.
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrdenTrabajoPersonalController : ControllerBase
    {
        private readonly OrdenTrabajoPersonalService service;
        private readonly ILogger<OrdenTrabajoPersonalController> logger;

        /// <summary>
        /// Inicializa el controlador de personal de orden de trabajo.
        /// </summary>
        /// <param name="service">Servicio del dominio de personal.</param>
        /// <param name="logger">Logger para registrar auditoría.</param>
        public OrdenTrabajoPersonalController(OrdenTrabajoPersonalService service, ILogger<OrdenTrabajoPersonalController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene un registro de personal por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Información del personal asignado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrdenTrabajoPersonal), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoPersonal>> ObtenerPorId(long id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el personal {PersonalId}", id);
                throw;
            }
        }

        /// <summary>
        /// Obtiene el personal asignado a una cabecera de orden de trabajo.
        /// </summary>
        /// <param name="ordenTrabajoCabeceraId">Identificador de la cabecera.</param>
        /// <returns>Lista de personal asociado.</returns>
        [HttpGet("cabecera/{ordenTrabajoCabeceraId}")]
        [ProducesResponseType(typeof(List<OrdenTrabajoPersonal>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<OrdenTrabajoPersonal>>> ObtenerPorCabecera(long ordenTrabajoCabeceraId)
        {
            try
            {
                var data = await service.ObtenerPorCabecera(ordenTrabajoCabeceraId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el personal de la cabecera {CabeceraId}", ordenTrabajoCabeceraId);
                throw;
            }
        }

        /// <summary>
        /// Registra un nuevo personal en una orden de trabajo.
        /// </summary>
        /// <param name="registro">Datos del personal a registrar.</param>
        /// <returns>Registro creado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(OrdenTrabajoPersonal), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoPersonal>> Agregar([FromBody] OrdenTrabajoPersonalCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar personal en la orden de trabajo");
                throw;
            }
        }

        /// <summary>
        /// Actualiza los datos del personal asignado a una orden de trabajo.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <param name="registro">Datos actualizados.</param>
        /// <returns>Registro actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdenTrabajoPersonal), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<OrdenTrabajoPersonal>> Modificar(long id, [FromBody] OrdenTrabajoPersonalCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar el personal {PersonalId}", id);
                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de personal asociado a una orden de trabajo.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
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
                logger.LogError(ex, "Error al eliminar el personal {PersonalId}", id);
                throw;
            }
        }
    }
}
