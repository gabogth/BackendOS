using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Security;
using nest.core.dominio.Security.Dto;
using nest.core.dominio;
using System.Security.Claims;

namespace nest.core.security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RolUsuarioController : Controller
    {
        private readonly RoleUsuarioService service;
        private readonly ILogger<RolUsuarioController> logger;
        public RolUsuarioController(RoleUsuarioService service, ILogger<RolUsuarioController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpPost("{roleName}")]
        public async Task<ActionResult<bool>> Merge(string roleName, [FromBody] List<string> usersId)
        {
            try
            {
                await this.service.Merge(roleName, usersId);
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
