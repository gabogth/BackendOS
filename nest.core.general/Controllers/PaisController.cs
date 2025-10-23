using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.Paises.Commands;
using nest.core.aplicacion.general.Features.Paises.Queries;
using nest.core.dominio;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.general.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<PaisController> logger;

        public PaisController(IMediator mediator, ILogger<PaisController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Pais>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Pais>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetPaisesQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pais), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Pais>> ObtenerPorId(int id)
        {
            try
            {
                var data = await mediator.Send(new GetPaisByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<Pais>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Pais>>> ObtenerActivos()
        {
            try
            {
                var data = await mediator.Send(new GetPaisesActivosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pais), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Pais>> Agregar([FromBody] CreatePaisCommand command)
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
        [ProducesResponseType(typeof(Pais), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Pais>> Modificar(int id, [FromBody] UpdatePaisCommand command)
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
                await mediator.Send(new DeletePaisCommand(id));
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
