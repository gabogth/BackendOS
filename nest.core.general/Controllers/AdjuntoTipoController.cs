using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.AdjuntoTipos.Commands;
using nest.core.aplicacion.general.Features.AdjuntoTipos.Queries;
using nest.core.dominio;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.general.Controllers
{
    /// <summary>
    /// Controlador para la administración de los tipos de adjuntos.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdjuntoTipoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<AdjuntoTipoController> logger;

        public AdjuntoTipoController(IMediator mediator, ILogger<AdjuntoTipoController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AdjuntoTipo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<AdjuntoTipo>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetAdjuntoTiposQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdjuntoTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoTipo>> ObtenerPorId(AdjuntoTipoEnum id)
        {
            try
            {
                var data = await mediator.Send(new GetAdjuntoTipoByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<AdjuntoTipo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<AdjuntoTipo>>> ObtenerActivos()
        {
            try
            {
                var data = await mediator.Send(new GetAdjuntoTiposActivosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(AdjuntoTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoTipo>> Agregar([FromBody] CreateAdjuntoTipoCommand command)
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
        [ProducesResponseType(typeof(AdjuntoTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoTipo>> Modificar(AdjuntoTipoEnum id, [FromBody] UpdateAdjuntoTipoCommand command)
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
        public async Task<ActionResult> Eliminar(AdjuntoTipoEnum id)
        {
            try
            {
                await mediator.Send(new DeleteAdjuntoTipoCommand(id));
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
