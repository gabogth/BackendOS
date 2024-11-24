using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Aplicacion;
using nest.core.aplicacion.security.Security;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using nest.core.dominio.Security;
using AutoMapper;

namespace nest.core.security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RolController : Controller
    {
        private readonly RoleService service;
        private readonly ILogger<RolController> logger;
        public RolController(RoleService service, ILogger<RolController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ApplicationRole>>> ObtenerTodos()
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
        public async Task<ActionResult<ApplicationRole>> ObtenerPorId(string id)
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
        public async Task<ActionResult<ApplicationRole>> Agregar([FromBody] ApplicationRole registro)
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

        [HttpPut]
        public async Task<ActionResult<ApplicationRole>> Modificar([FromBody] ApplicationRole registro)
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
        public async Task<ActionResult> Eliminar([FromBody] ApplicationRole registro)
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
    }
}
