using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.GrupoTrabajoServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para la gestión de grupos de trabajo y su detalle de personas.
    /// Permite realizar operaciones CRUD respetando la estructura maestro-detalle.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GrupoTrabajoController : ControllerBase
    {
        private readonly GrupoTrabajoService service;
        private readonly ILogger<GrupoTrabajoController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador <see cref="GrupoTrabajoController"/>.
        /// </summary>
        /// <param name="service">Servicio de negocio para grupos de trabajo.</param>
        /// <param name="logger">Logger para registrar auditoría y errores.</param>
        public GrupoTrabajoController(GrupoTrabajoService service, ILogger<GrupoTrabajoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todos los grupos de trabajo registrados.
        /// </summary>
        /// <returns>Lista de grupos de trabajo.</returns>
        /// <response code="200">Devuelve la lista de grupos de trabajo.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<GrupoTrabajo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<GrupoTrabajo>>> ObtenerTodos()
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
        /// Obtiene un grupo de trabajo por su identificador.
        /// </summary>
        /// <param name="id">Identificador del grupo de trabajo.</param>
        /// <returns>Grupo de trabajo asociado al identificador.</returns>
        /// <response code="200">Grupo de trabajo encontrado.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GrupoTrabajo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<GrupoTrabajo>> ObtenerPorId(long id)
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
        /// Obtiene los grupos de trabajo activos.
        /// </summary>
        /// <returns>Lista de grupos de trabajo con estado activo.</returns>
        /// <response code="200">Devuelve la lista de grupos de trabajo activos.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<GrupoTrabajo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<GrupoTrabajo>>> ObtenerActivos()
        {
            try
            {
                var data = await service.ObtenerActivos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo grupo de trabajo con sus integrantes.
        /// </summary>
        /// <param name="registro">Información del grupo y su detalle de personas.</param>
        /// <returns>Grupo de trabajo creado.</returns>
        /// <response code="200">Grupo de trabajo registrado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(GrupoTrabajo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<GrupoTrabajo>> Agregar([FromBody] GrupoTrabajoDto registro)
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
        /// Actualiza la información de un grupo de trabajo y sus integrantes.
        /// </summary>
        /// <param name="id">Identificador del grupo de trabajo.</param>
        /// <param name="registro">Información actualizada del grupo y detalle de personas.</param>
        /// <returns>Grupo de trabajo actualizado.</returns>
        /// <response code="200">Grupo de trabajo modificado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GrupoTrabajo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<GrupoTrabajo>> Modificar(long id, [FromBody] GrupoTrabajoDto registro)
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
        /// Elimina un grupo de trabajo existente.
        /// </summary>
        /// <param name="id">Identificador del grupo de trabajo a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Grupo de trabajo eliminado correctamente.</response>
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
