using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.AdjuntoServices;
using nest.core.dominio;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;
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
        [HttpPost("{modulo}")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(Adjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Adjunto>> Agregar([FromForm] AdjuntoUploadRequest request, [FromRoute]AdjuntoConfigProviderModuloEnum modulo, CancellationToken cancellationToken = default)
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
                Console.WriteLine(uploadDto.ToString());
                var data = await service.Agregar(modulo, uploadDto, cancellationToken);
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
        [HttpPut("{modulo}/{id}")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(Adjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Adjunto>> Modificar([FromRoute] long id, [FromForm] AdjuntoUploadRequest request, [FromRoute] AdjuntoConfigProviderModuloEnum modulo, CancellationToken cancellationToken = default)
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

                var data = await service.Modificar(id, modulo, uploadDto, cancellationToken);
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

        /// <summary>
        /// Obtiene la url de un attachment para su descarga.
        /// </summary>
        [HttpGet("download/{id}")]
        [ProducesResponseType(typeof(Adjunto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<string>> ObtenerUrl([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var data = await service.ObtenerUrlDescarga(id, cancellationToken);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
