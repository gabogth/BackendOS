using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.Features.LicenciasConducir.Commands;
using nest.core.aplicacion.general.Features.LicenciasConducir.Queries;
using nest.core.dominio;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.general.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LicenciaConducirController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<LicenciaConducirController> logger;

        public LicenciaConducirController(IMediator mediator, ILogger<LicenciaConducirController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<LicenciaConducir>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<LicenciaConducir>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetLicenciasConducirQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LicenciaConducir), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<LicenciaConducir>> ObtenerPorId(byte id)
        {
            try
            {
                var data = await mediator.Send(new GetLicenciaConducirByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<LicenciaConducir>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<LicenciaConducir>>> ObtenerActivos()
        {
            try
            {
                var data = await mediator.Send(new GetLicenciasConducirActivasQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(LicenciaConducir), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<LicenciaConducir>> Agregar([FromBody] CreateLicenciaConducirCommand command)
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
        [ProducesResponseType(typeof(LicenciaConducir), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<LicenciaConducir>> Modificar(byte id, [FromBody] UpdateLicenciaConducirCommand command)
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
                await mediator.Send(new DeleteLicenciaConducirCommand(id));
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
