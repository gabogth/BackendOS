using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.RegistroAsistenciaServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para la gestión de registros de asistencia.
    /// Permite consultar, crear, actualizar y eliminar marcaciones de asistencia del personal.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RegistroAsistenciaController : ControllerBase
    {
        private readonly RegistroAsistenciaService service;
        private readonly ILogger<RegistroAsistenciaController> logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador <see cref="RegistroAsistenciaController"/>.
        /// </summary>
        /// <param name="service">Servicio de aplicación que gestiona la lógica de registros de asistencia.</param>
        /// <param name="logger">Instancia de <see cref="ILogger"/> para el registro de eventos.</param>
        public RegistroAsistenciaController(RegistroAsistenciaService service, ILogger<RegistroAsistenciaController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todos los registros de asistencia disponibles.
        /// </summary>
        /// <returns>Lista de registros de asistencia.</returns>
        /// <response code="200">Devuelve la colección de registros de asistencia.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<RegistroAsistencia>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<RegistroAsistencia>>> ObtenerTodos()
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
        /// Obtiene un registro de asistencia específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro de asistencia.</param>
        /// <returns>Registro de asistencia correspondiente.</returns>
        /// <response code="200">Registro encontrado.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RegistroAsistencia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistencia>> ObtenerPorId(long id)
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
        /// Busca registros de asistencia de un personal en un rango de fechas.
        /// </summary>
        /// <param name="personalId">Identificador del personal.</param>
        /// <param name="fechaInicio">Fecha inicial del filtro (inclusive).</param>
        /// <param name="fechaFin">Fecha final del filtro (inclusive).</param>
        /// <returns>Lista de registros de asistencia que coinciden con el filtro.</returns>
        /// <response code="200">Devuelve la lista filtrada de registros.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("personal/{personalId}")]
        [ProducesResponseType(typeof(List<RegistroAsistencia>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<RegistroAsistencia>>> BuscarPorRangoFecha(int personalId, [FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                var data = await service.BuscarPorRangoFecha(personalId, fechaInicio, fechaFin);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo registro de asistencia.
        /// </summary>
        /// <param name="registro">Datos del registro de asistencia a crear.</param>
        /// <returns>Registro de asistencia creado.</returns>
        /// <response code="200">Registro creado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(RegistroAsistencia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistencia>> Agregar([FromBody] RegistroAsistenciaCrearDto registro)
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
        /// Crea un nuevo registro de asistencia.
        /// </summary>
        /// <param name="registro">Datos del registro de asistencia a crear.</param>
        /// <returns>Registro de asistencia creado.</returns>
        /// <response code="200">Registro creado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost("serverdt")]
        [ProducesResponseType(typeof(RegistroAsistencia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistencia>> AgregarConDatetime([FromBody] RegistroAsistenciaCrearDto registro)
        {
            try
            {
                registro.Fecha = DateTime.Now;
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
        /// Crea un nuevo registro de asistencia utilizando los parametros del token como inicio de sesion.
        /// </summary>
        /// <returns>Registro de asistencia creado.</returns>
        /// <response code="200">Registro creado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost("current_user")]
        [ProducesResponseType(typeof(RegistroAsistencia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistencia>> AgregarUsuarioActual([FromBody] RegistroAsistenciaCrearDto registro)
        {
            try
            {
                var data = await service.AgregarUsuarioActual(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un registro de asistencia existente.
        /// </summary>
        /// <param name="id">Identificador del registro que se desea actualizar.</param>
        /// <param name="registro">Datos actualizados del registro de asistencia.</param>
        /// <returns>Registro de asistencia actualizado.</returns>
        /// <response code="200">Registro actualizado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RegistroAsistencia), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistencia>> Modificar(long id, [FromBody] RegistroAsistenciaCrearDto registro)
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
        /// Elimina un registro de asistencia.
        /// </summary>
        /// <param name="id">Identificador del registro a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Registro eliminado correctamente.</response>
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
