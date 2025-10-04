using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionActivoServices;
using nest.core.dominio;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.patrimonial.Controllers
{
    /// <summary>
    /// Controlador para la gestión de ubicaciones físicas asignadas a los activos.
    /// Permite consultar el historial de ubicaciones, registrar nuevos traslados y actualizar registros existentes.
    /// Todos los endpoints requieren autorización mediante token JWT válido.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UbicacionActivoController : ControllerBase
    {
        private readonly UbicacionActivoService service;
        private readonly ILogger<UbicacionActivoController> logger;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UbicacionActivoController"/>.
        /// </summary>
        /// <param name="service">Servicio de aplicación para gestionar ubicaciones de activos.</param>
        /// <param name="logger">Registrador para auditoría y trazabilidad.</param>
        public UbicacionActivoController(UbicacionActivoService service, ILogger<UbicacionActivoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones registradas para todos los activos.
        /// </summary>
        /// <returns>Lista con los registros de ubicación.</returns>
        /// <response code="200">Listado obtenido correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<UbicacionActivo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<UbicacionActivo>>> ObtenerTodos()
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
        /// Obtiene las ubicaciones históricas asociadas a un activo específico.
        /// </summary>
        /// <param name="activoId">Identificador del activo a consultar.</param>
        /// <returns>Listado de ubicaciones pertenecientes al activo.</returns>
        /// <response code="200">Listado obtenido correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpGet("activo/{activoId:long}")]
        [ProducesResponseType(typeof(List<UbicacionActivo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<UbicacionActivo>>> ObtenerPorActivo(long activoId)
        {
            try
            {
                var data = await service.ObtenerPorActivo(activoId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un registro de ubicación por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro de ubicación.</param>
        /// <returns>Registro encontrado.</returns>
        /// <response code="200">Registro encontrado.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(UbicacionActivo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<UbicacionActivo>> ObtenerPorId(long id)
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
        /// Registra una nueva ubicación para un activo.
        /// </summary>
        /// <param name="registro">Datos del traslado a registrar.</param>
        /// <returns>Registro creado.</returns>
        /// <response code="200">Registro creado correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(UbicacionActivo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<UbicacionActivo>> Agregar([FromBody] UbicacionActivoCrearDto registro)
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
        /// Actualiza la información de una ubicación existente.
        /// </summary>
        /// <param name="id">Identificador del registro a modificar.</param>
        /// <param name="registro">Datos actualizados del traslado.</param>
        /// <returns>Registro actualizado.</returns>
        /// <response code="200">Registro actualizado correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(UbicacionActivo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<UbicacionActivo>> Modificar(long id, [FromBody] UbicacionActivoCrearDto registro)
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
        /// Elimina un registro de ubicación.
        /// </summary>
        /// <param name="id">Identificador del registro a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Registro eliminado correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
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
