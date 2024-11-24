using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Aplicacion;
using nest.core.dominio;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ModuloController : Controller
    {
        private readonly ModuloService service;
        private readonly ILogger<ModuloController> logger;
        public ModuloController(ModuloService service, ILogger<ModuloController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Modulo>>> ObtenerTodos()
        {
            try
            {
                var data = await this.service.ObtenerTodos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> ObtenerPorId(int id)
        {
            try
            {
                var data = await this.service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpPost("filter")]
        public async Task<ActionResult<Modulo>> ObtenerPorUnaPropiedad([FromBody] Dictionary<string, object> filtros)
        {
            try
            {
                var data = await this.service.ObtenerPorUnaPropiedad(filtros);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Modulo>> Agregar([FromBody] ModuloCrearDto registro)
        {
            try
            {
                var data = await this.service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Modulo>> Modificar(int id, [FromBody]ModuloCrearDto registro)
        {
            try
            {
                var data = await this.service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await this.service.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }
    }
}
