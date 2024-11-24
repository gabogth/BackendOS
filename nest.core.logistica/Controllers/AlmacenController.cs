using Microsoft.AspNetCore.Mvc;
using nest.core.dominio;
using nest.core.aplicacion.logistica;
using nest.core.dominio.Logistica.AlmacenEN;
using Microsoft.AspNetCore.Authorization;

namespace nest.core.logistica.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private readonly AlmacenService service;
        private readonly ILogger<AlmacenController> logger;
        public AlmacenController(AlmacenService service, ILogger<AlmacenController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Almacen>>> ObtenerTodos()
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
        public async Task<ActionResult<Almacen>> ObtenerPorId(int id)
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

        [HttpGet("activos")]
        public async Task<ActionResult<List<Almacen>>> ObtenerActivos()
        {
            try
            {
                var data = await this.service.ObtenerActivos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Almacen>> Agregar([FromBody] AlmacenCrearDto registro)
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
        public async Task<ActionResult<Almacen>> Modificar(int id, [FromBody] AlmacenCrearDto registro)
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
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }
    }
}
