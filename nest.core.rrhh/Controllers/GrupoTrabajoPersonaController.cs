using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonaServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para administrar las asignaciones de personas a grupos de trabajo.
    /// Permite gestionar el detalle independiente de la cabecera de grupos.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GrupoTrabajoPersonaController : ControllerBase
    {
        private readonly GrupoTrabajoPersonaService service;
        private readonly ILogger<GrupoTrabajoPersonaController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador <see cref="GrupoTrabajoPersonaController"/>.
        /// </summary>
        /// <param name="service">Servicio de negocio para el detalle de grupos de trabajo.</param>
        /// <param name="logger">Logger para seguimiento y auditoría.</param>
        public GrupoTrabajoPersonaController(GrupoTrabajoPersonaService service, ILogger<GrupoTrabajoPersonaController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las asignaciones de personas a grupos de trabajo.
        /// </summary>
        /// <returns>Listado de asignaciones registradas.</returns>
        /// <response code="200">Devuelve la lista completa de asignaciones.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<GrupoTrabajoPersona>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<GrupoTrabajoPersona>>> ObtenerTodos()
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
        /// Obtiene una asignación específica por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Asignación encontrada.</returns>
        /// <response code="200">Asignación encontrada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GrupoTrabajoPersona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<GrupoTrabajoPersona>> ObtenerPorId(long id)
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
        /// Obtiene las asignaciones registradas para un grupo de trabajo específico.
        /// </summary>
        /// <param name="grupoTrabajoId">Identificador del grupo de trabajo.</param>
        /// <returns>Listado de personas asociadas al grupo.</returns>
        /// <response code="200">Devuelve las asignaciones filtradas por grupo.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("grupo/{grupoTrabajoId}")]
        [ProducesResponseType(typeof(List<GrupoTrabajoPersona>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<GrupoTrabajoPersona>>> ObtenerPorGrupoTrabajo(long grupoTrabajoId)
        {
            try
            {
                var data = await service.ObtenerPorGrupoTrabajo(grupoTrabajoId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Registra una nueva persona dentro de un grupo de trabajo.
        /// </summary>
        /// <param name="registro">Datos de la asignación a registrar.</param>
        /// <returns>Asignación creada.</returns>
        /// <response code="200">La asignación fue registrada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(GrupoTrabajoPersona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<GrupoTrabajoPersona>> Agregar([FromBody] GrupoTrabajoPersonaCrearDto registro)
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
        /// Actualiza la información de una asignación existente.
        /// </summary>
        /// <param name="id">Identificador de la asignación.</param>
        /// <param name="registro">Datos actualizados de la asignación.</param>
        /// <returns>Asignación actualizada.</returns>
        /// <response code="200">La asignación fue actualizada correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GrupoTrabajoPersona), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<GrupoTrabajoPersona>> Modificar(long id, [FromBody] GrupoTrabajoPersonaCrearDto registro)
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
        /// Elimina una asignación de persona a grupo de trabajo.
        /// </summary>
        /// <param name="id">Identificador de la asignación a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">La asignación fue eliminada.</response>
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
