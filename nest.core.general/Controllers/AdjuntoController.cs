using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.Adjuntos.Commands;
using nest.core.aplicacion.general.Features.Adjuntos.Queries;
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
        private readonly IMediator mediator;
        private readonly ILogger<AdjuntoController> logger;

        public AdjuntoController(IMediator mediator, ILogger<AdjuntoController> logger)
        {
            this.mediator = mediator;
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
                var data = await mediator.Send(new GetAdjuntosQuery());
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
                var data = await mediator.Send(new GetAdjuntoByIdQuery(id));
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
                var data = await mediator.Send(new CreateAdjuntoCommand(modulo, uploadDto), cancellationToken);
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

                var data = await mediator.Send(new UpdateAdjuntoCommand(id, modulo, uploadDto), cancellationToken);
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
                await mediator.Send(new DeleteAdjuntoCommand(id), cancellationToken);
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
