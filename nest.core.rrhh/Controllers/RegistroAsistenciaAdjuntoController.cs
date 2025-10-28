using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Queries;
using nest.core.dominio;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para la administración de adjuntos asociados a registros de asistencia.
    /// Permite gestionar el vínculo entre las marcaciones y los archivos almacenados en el sistema.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RegistroAsistenciaAdjuntoController : ControllerBase
    {
        private readonly ISender sender;

        public RegistroAsistenciaAdjuntoController(ISender sender)
        {
            this.sender = sender;
        }

        /// <summary>
        /// Obtiene todos los adjuntos vinculados a registros de asistencia.
        /// </summary>
        /// <returns>Listado de adjuntos de registros de asistencia.</returns>
        /// <response code="200">Adjuntos recuperados correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<RegistroAsistenciaAdjunto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<RegistroAsistenciaAdjunto>>> ObtenerTodos(CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerTodosQuery(), ct);
            return Ok(data);
        }

        /// <summary>
        /// Obtiene el adjunto de un registro de asistencia específico.
        /// </summary>
        /// <param name="id">Identificador del registro de asistencia.</param>
        /// <returns>Adjunto vinculado al registro indicado.</returns>
        /// <response code="200">Adjunto recuperado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RegistroAsistenciaAdjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaAdjunto>> ObtenerPorId(long id, CancellationToken ct)
        {
            var data = await sender.Send(new ObtenerPorIdQuery(id), ct);
            return Ok(data);
        }

        /// <summary>
        /// Crea o actualiza la relación entre un registro de asistencia y un adjunto.
        /// </summary>
        /// <param name="command">Datos del adjunto asociado al registro de asistencia.</param>
        /// <returns>Adjunto registrado.</returns>
        /// <response code="200">Adjunto vinculado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPost]
        [ProducesResponseType(typeof(RegistroAsistenciaAdjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaAdjunto>> Agregar([FromBody] RegistroAsistenciaAdjuntoCrearCommand command, CancellationToken ct)
        {
            var data = await sender.Send(command, ct);
            return Ok(data);
        }

        /// <summary>
        /// Actualiza la información del adjunto asociado a un registro de asistencia.
        /// </summary>
        /// <param name="id">Identificador del registro de asistencia.</param>
        /// <param name="command">Datos actualizados del adjunto.</param>
        /// <returns>Adjunto actualizado.</returns>
        /// <response code="200">Adjunto actualizado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RegistroAsistenciaAdjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<RegistroAsistenciaAdjunto>> Modificar(long id, [FromBody] RegistroAsistenciaAdjuntoModificarCommand command, CancellationToken ct)
        {
            var cmd = command with { RegistroAsistenciaId = id };
            var data = await sender.Send(cmd, ct);
            return Ok(data);
        }

        /// <summary>
        /// Elimina el adjunto asociado a un registro de asistencia.
        /// </summary>
        /// <param name="id">Identificador del registro de asistencia.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Adjunto eliminado correctamente.</response>
        /// <response code="400">Error en la solicitud.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(long id, CancellationToken ct)
        {
            await sender.Send(new RegistroAsistenciaAdjuntoEliminarCommand(id), ct);
            return Ok(true);
        }
    }
}
