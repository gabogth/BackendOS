using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionTecnicaServices;
using nest.core.dominio;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.patrimonial.Controllers
{
    /// <summary>
    /// Controlador para la administración de ubicaciones técnicas.
    /// Permite consultar la estructura jerárquica de ubicaciones y mantener su catálogo.
    /// Todos los endpoints requieren autorización mediante token JWT válido.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UbicacionTecnicaController : ControllerBase
    {
        private readonly UbicacionTecnicaService service;
        private readonly ILogger<UbicacionTecnicaController> logger;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UbicacionTecnicaController"/>.
        /// </summary>
        /// <param name="service">Servicio de aplicación para gestionar ubicaciones técnicas.</param>
        /// <param name="logger">Registrador para auditoría y trazabilidad.</param>
        public UbicacionTecnicaController(UbicacionTecnicaService service, ILogger<UbicacionTecnicaController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones técnicas registradas.
        /// </summary>
        /// <returns>Listado completo de ubicaciones técnicas.</returns>
        /// <response code="200">Listado obtenido correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<UbicacionTecnica>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<UbicacionTecnica>>> ObtenerTodos()
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
        /// Obtiene las ubicaciones técnicas activas.
        /// </summary>
        /// <returns>Listado de ubicaciones disponibles para asignación.</returns>
        /// <response code="200">Listado obtenido correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpGet("activas")]
        [ProducesResponseType(typeof(List<UbicacionTecnica>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<UbicacionTecnica>>> ObtenerActivas()
        {
            try
            {
                var data = await service.ObtenerActivas();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene una ubicación técnica por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la ubicación técnica.</param>
        /// <returns>Ubicación encontrada.</returns>
        /// <response code="200">Ubicación encontrada.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(UbicacionTecnica), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<UbicacionTecnica>> ObtenerPorId(long id)
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
        /// Registra una nueva ubicación técnica.
        /// </summary>
        /// <param name="registro">Datos de la ubicación técnica.</param>
        /// <returns>Ubicación creada.</returns>
        /// <response code="200">Registro creado correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(UbicacionTecnica), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<UbicacionTecnica>> Agregar([FromBody] UbicacionTecnicaCrearDto registro)
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
        /// Actualiza una ubicación técnica existente.
        /// </summary>
        /// <param name="id">Identificador de la ubicación técnica.</param>
        /// <param name="registro">Información a actualizar.</param>
        /// <returns>Ubicación actualizada.</returns>
        /// <response code="200">Registro actualizado correctamente.</response>
        /// <response code="400">La solicitud es inválida.</response>
        /// <response code="401">No autorizado.</response>
        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(UbicacionTecnica), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<UbicacionTecnica>> Modificar(long id, [FromBody] UbicacionTecnicaCrearDto registro)
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
        /// Elimina una ubicación técnica.
        /// </summary>
        /// <param name="id">Identificador de la ubicación técnica.</param>
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
