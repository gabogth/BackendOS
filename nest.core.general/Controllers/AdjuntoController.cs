using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoServices;
using nest.core.dominio;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.general.Controllers.Requests;

namespace nest.core.general.Controllers
{
    /// <summary>
    /// Gestiona los archivos adjuntos.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdjuntoController : ControllerBase
    {
        private readonly AdjuntoService service;
        private readonly ILogger<AdjuntoController> logger;

        public AdjuntoController(AdjuntoService service, ILogger<AdjuntoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todos los adjuntos registrados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<Adjunto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Adjunto>>> ObtenerTodos()
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
        /// Obtiene un adjunto por su identificador.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Adjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Adjunto>> ObtenerPorId(long id)
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
        /// Registra un nuevo adjunto.
        /// </summary>
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(Adjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Adjunto>> Agregar([FromForm] AdjuntoUploadRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (request.Archivo is null || request.Archivo.Length == 0)
                    return BadRequest(new ErrorMessage { Message = "Debe adjuntar un archivo válido." });

                var uploadDto = new AdjuntoUploadDto
                {
                    Content = request.Archivo.OpenReadStream(),
                    FileName = request.Archivo.FileName,
                    ContentType = request.Archivo.ContentType,
                    Size = request.Archivo.Length
                };

                var data = await service.Agregar(request.Modulo, uploadDto, cancellationToken);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un adjunto existente.
        /// </summary>
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(Adjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Adjunto>> Modificar(long id, [FromForm] AdjuntoUploadRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                if (request.Archivo is null || request.Archivo.Length == 0)
                    return BadRequest(new ErrorMessage { Message = "Debe adjuntar un archivo válido." });

                var uploadDto = new AdjuntoUploadDto
                {
                    Content = request.Archivo.OpenReadStream(),
                    FileName = request.Archivo.FileName,
                    ContentType = request.Archivo.ContentType,
                    Size = request.Archivo.Length
                };

                var data = await service.Modificar(id, request.Modulo, uploadDto, cancellationToken);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Elimina un adjunto.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await service.Eliminar(id, cancellationToken);
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
