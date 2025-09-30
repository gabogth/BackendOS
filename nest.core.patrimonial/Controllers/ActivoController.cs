using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.patrimonial.ActivoServices;
using nest.core.dominio;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.patrimonial.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ActivoController : ControllerBase
    {
        private readonly ActivoService service;
        private readonly ILogger<ActivoController> logger;
        public ActivoController(ActivoService service, ILogger<ActivoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Activo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<Activo>>> ObtenerTodos()
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

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(Activo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Activo>> ObtenerPorId(long id)
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

        [HttpPost]
        [ProducesResponseType(typeof(Activo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Activo>> Agregar([FromBody] ActivoCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(Activo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<Activo>> Modificar(long id, [FromBody] ActivoCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(long id)
        {
            try
            {
                await service.Eliminar(id);
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
