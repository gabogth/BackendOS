using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.Distritos.Commands;
using nest.core.aplicacion.general.Features.Distritos.Queries;
using nest.core.dominio;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.general.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DistritoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<DistritoController> logger;

        public DistritoController(IMediator mediator, ILogger<DistritoController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Distrito>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Distrito>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetDistritosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Distrito), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Distrito>> ObtenerPorId(int id)
        {
            try
            {
                var data = await mediator.Send(new GetDistritoByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Distrito), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Distrito>> Agregar([FromBody] CreateDistritoCommand command)
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
        [ProducesResponseType(typeof(Distrito), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Distrito>> Modificar(int id, [FromBody] UpdateDistritoCommand command)
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
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await mediator.Send(new DeleteDistritoCommand(id));
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
