using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.corporativo;
using nest.core.dominio;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.corporativo.Controllers
{
    /// <summary>
    /// Controlador para la gestión de estructuras organizacionales.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EstructuraOrganizacionalController : ControllerBase
    {
        private readonly EstructuraOrganizacionalService service;
        private readonly ILogger<EstructuraOrganizacionalController> logger;

        public EstructuraOrganizacionalController(EstructuraOrganizacionalService service, ILogger<EstructuraOrganizacionalController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EstructuraOrganizacional>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<EstructuraOrganizacional>>> ObtenerTodos()
        {
            try
            {
                var data = await service.ObtenerTodos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EstructuraOrganizacional), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<EstructuraOrganizacional>> ObtenerPorId(int id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<EstructuraOrganizacional>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<EstructuraOrganizacional>>> ObtenerActivos()
        {
            try
            {
                var data = await service.ObtenerActivos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(EstructuraOrganizacional), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<EstructuraOrganizacional>> Agregar([FromBody] EstructuraOrganizacionalCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EstructuraOrganizacional), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<EstructuraOrganizacional>> Modificar(int id, [FromBody] EstructuraOrganizacionalCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await service.Eliminar(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }
    }
}
