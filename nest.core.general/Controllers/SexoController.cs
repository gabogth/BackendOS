using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.Sexos.Commands;
using nest.core.aplicacion.general.Features.Sexos.Queries;
using nest.core.dominio;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.general.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SexoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<SexoController> logger;

        public SexoController(IMediator mediator, ILogger<SexoController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Sexo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Sexo>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetSexosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Sexo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Sexo>> ObtenerPorId(byte id)
        {
            try
            {
                var data = await mediator.Send(new GetSexoByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<Sexo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Sexo>>> ObtenerActivos()
        {
            try
            {
                var data = await mediator.Send(new GetSexosActivosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Sexo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Sexo>> Agregar([FromBody] CreateSexoCommand command)
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
        [ProducesResponseType(typeof(Sexo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Sexo>> Modificar(byte id, [FromBody] UpdateSexoCommand command)
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
                await mediator.Send(new DeleteSexoCommand(id));
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
