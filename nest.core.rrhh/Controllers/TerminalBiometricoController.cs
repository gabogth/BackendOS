using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Queries;
using nest.core.dominio;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.rrhh.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class TerminalBiometricoController : ControllerBase
{
    private readonly ISender sender;

    public TerminalBiometricoController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<TerminalBiometrico>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<List<TerminalBiometrico>>> ObtenerTodos(CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerTerminalBiometricosQuery(), ct);
        return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TerminalBiometrico), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<TerminalBiometrico>> ObtenerPorId(int id, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerTerminalBiometricoPorIdQuery(id), ct);
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(typeof(TerminalBiometrico), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<TerminalBiometrico>> Agregar([FromBody] TerminalBiometricoCrearCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command, ct);
        return Ok(data);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TerminalBiometrico), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<TerminalBiometrico>> Modificar(int id, [FromBody] TerminalBiometricoModificarCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command with { Id = id }, ct);
        return Ok(data);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult> Eliminar(int id, CancellationToken ct)
    {
        await sender.Send(new TerminalBiometricoEliminarCommand(id), ct);
        return Ok();
    }
}
