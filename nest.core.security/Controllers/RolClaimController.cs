using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.RoleClaims.Commands;
using nest.core.dominio;
using nest.core.dominio.Security.Dto;

namespace nest.core.security.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RolClaimController : Controller
{
    private readonly ISender sender;

    public RolClaimController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost("{roleId}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<bool>> Merge(string roleId, [FromBody] List<ClaimDto> claims, CancellationToken ct)
    {
        await sender.Send(new RoleClaimsMergeCommand(roleId, claims), ct);
        return Ok(true);
    }
}
