using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Aplicacion;
using nest.core.dominio;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FormularioController : Controller
    {
        private readonly FormularioService service;
        private readonly ILogger<FormularioController> logger;
        public FormularioController(FormularioService service, ILogger<FormularioController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Formulario>>> ObtenerTodos()
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
        public async Task<ActionResult<Formulario>> ObtenerPorId(int id)
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

        [HttpGet("modulo/{moduloId}")]
        public async Task<ActionResult<List<Formulario>>> ObtenerPorModuloId(int moduloId)
        {
            try
            {
                var data = await this.service.ObtenerPorModuloId(moduloId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpPost("filter")]
        public async Task<ActionResult<Formulario>> ObtenerPorUnaPropiedad([FromBody] Dictionary<string, object> filtros)
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

        [HttpGet("rol/{roleId}")]
        public async Task<ActionResult<List<Formulario>>> ObtenerPorRolId(string roleId)
        {
            try
            {
                var data = await this.service.ObtenerPorRolId(roleId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Formulario>> Agregar([FromBody] FormularioCrearDto registro)
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
        public async Task<ActionResult<Formulario>> Modificar(int id, [FromBody] FormularioCrearDto registro)
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
