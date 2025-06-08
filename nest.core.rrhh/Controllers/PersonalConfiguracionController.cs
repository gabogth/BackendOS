using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.PersonalConfiguracionServices;
using nest.core.dominio;
using nest.core.dominio.RRHH.PersonalConfiguracionEntities;

namespace nest.core.rrhh.Controllers
{
    /// <summary>
    /// Controlador para la gestión de configuraciones de personal.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PersonalConfiguracionController : ControllerBase
    {
        private readonly PersonalConfiguracionService service;
        private readonly ILogger<PersonalConfiguracionController> logger;

        public PersonalConfiguracionController(PersonalConfiguracionService service, ILogger<PersonalConfiguracionController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PersonalConfiguracion>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<PersonalConfiguracion>>> ObtenerTodos()
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
        [ProducesResponseType(typeof(PersonalConfiguracion), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonalConfiguracion>> ObtenerPorId(int id)
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

        [HttpPost]
        [ProducesResponseType(typeof(PersonalConfiguracion), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonalConfiguracion>> Agregar([FromBody] PersonalConfiguracionCrearDto registro)
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
        [ProducesResponseType(typeof(PersonalConfiguracion), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<PersonalConfiguracion>> Modificar(int id, [FromBody] PersonalConfiguracionCrearDto registro)
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
