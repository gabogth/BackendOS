using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Security;
using nest.core.dominio.Security;
using nest.core.dominio;
using static System.Runtime.InteropServices.JavaScript.JSType;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService service;
        private readonly ILogger<UsuarioController> logger;
        public UsuarioController(UsuarioService service, ILogger<UsuarioController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ApplicationUser>>> ObtenerTodos()
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
        public async Task<ActionResult<ApplicationUser>> ObtenerPorId(string id)
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

        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Agregar([FromBody] ApplicationUserDto registro)
        {
            try
            {
                var data = await this.service.Agregar(registro.User, registro.Password);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<ApplicationUser>> Modificar([FromBody] ApplicationUser registro)
        {
            try
            {
                var data = await this.service.Modificar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Eliminar([FromBody] ApplicationUser registro)
        {
            try
            {
                await this.service.Eliminar(registro);
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpGet("rol/{roleName}")]
        public async Task<ActionResult<List<ApplicationUser>>> ObtenerPorRolName(string roleName)
        {
            try
            {
                var data = await this.service.ObtenerPorRol(roleName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }
    }
}
