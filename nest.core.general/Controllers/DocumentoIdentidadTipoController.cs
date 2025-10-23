using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.DocumentosIdentidadTipo.Commands;
using nest.core.aplicacion.general.Features.DocumentosIdentidadTipo.Queries;
using nest.core.dominio;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.general.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DocumentoIdentidadTipoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<DocumentoIdentidadTipoController> logger;

        public DocumentoIdentidadTipoController(IMediator mediator, ILogger<DocumentoIdentidadTipoController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DocumentoIdentidadTipo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<DocumentoIdentidadTipo>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetDocumentosIdentidadTipoQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DocumentoIdentidadTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<DocumentoIdentidadTipo>> ObtenerPorId(byte id)
        {
            try
            {
                var data = await mediator.Send(new GetDocumentoIdentidadTipoByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<DocumentoIdentidadTipo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<DocumentoIdentidadTipo>>> ObtenerActivos()
        {
            try
            {
                var data = await mediator.Send(new GetDocumentosIdentidadTipoActivosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(DocumentoIdentidadTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<DocumentoIdentidadTipo>> Agregar([FromBody] CreateDocumentoIdentidadTipoCommand command)
        {
            try
            {
                var data = await mediator.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DocumentoIdentidadTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<DocumentoIdentidadTipo>> Modificar(byte id, [FromBody] UpdateDocumentoIdentidadTipoCommand command)
        {
            try
            {
                var data = await mediator.Send(command with { Id = id });
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(byte id)
        {
            try
            {
                await mediator.Send(new DeleteDocumentoIdentidadTipoCommand(id));
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
