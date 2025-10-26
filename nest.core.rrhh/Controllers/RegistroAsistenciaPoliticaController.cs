using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Queries;
using nest.core.dominio;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.rrhh.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class RegistroAsistenciaPoliticaController : ControllerBase
{
    private readonly ISender sender;

    public RegistroAsistenciaPoliticaController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<RegistroAsistenciaPolitica>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<List<RegistroAsistenciaPolitica>>> ObtenerTodos(CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerRegistroAsistenciaPoliticasQuery(), ct);
        return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RegistroAsistenciaPolitica), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<RegistroAsistenciaPolitica>> ObtenerPorId(long id, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerRegistroAsistenciaPoliticaPorIdQuery(id), ct);
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RegistroAsistenciaPolitica), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<RegistroAsistenciaPolitica>> Agregar([FromBody] RegistroAsistenciaPoliticaCrearCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command, ct);
        return Ok(data);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(RegistroAsistenciaPolitica), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<RegistroAsistenciaPolitica>> Modificar(long id, [FromBody] RegistroAsistenciaPoliticaModificarCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command with { Id = id }, ct);
        return Ok(data);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult> Eliminar(long id, CancellationToken ct)
    {
        await sender.Send(new RegistroAsistenciaPoliticaEliminarCommand(id), ct);
        return Ok();
    }
}
