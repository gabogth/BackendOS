using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Security;
using nest.core.dominio.Security;
using nest.core.dominio;
using System.Security.Claims;
using nest.core.dominio.Security.Dto;

namespace nest.core.security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RolClaimController : Controller
    {
        private readonly RoleClaimsService service;
        private readonly ILogger<RolClaimController> logger;
        public RolClaimController(RoleClaimsService service, ILogger<RolClaimController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpPost("{roleId}")]
        public async Task<ActionResult<bool>> Merge(string roleId, [FromBody] List<ClaimDto> claims)
        {
            try
            {
                List<Claim> claimsOt = claims.Select(x => new Claim(x.Type, x.Value)).ToList();
                await this.service.Merge(roleId, claimsOt);
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
