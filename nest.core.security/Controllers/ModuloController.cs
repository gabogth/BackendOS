using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Modulos.Commands;
using nest.core.aplicacion.security.Modulos.Queries;
using nest.core.dominio;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.security.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ModuloController : Controller
{
    private readonly ISender sender;

    public ModuloController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Modulo>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Modulo>>> ObtenerTodos(CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerModulosQuery(), ct);
        return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Modulo), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<Modulo>> ObtenerPorId(int id, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerModuloPorIdQuery(id), ct);
        return Ok(data);
    }

    [HttpPost("filter")]
    [ProducesResponseType(typeof(List<Modulo>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Modulo>>> ObtenerPorUnaPropiedad([FromBody] Dictionary<string, object?> filtros, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerModulosPorFiltroQuery(filtros), ct);
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Modulo), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<Modulo>> Agregar([FromBody] ModuloCrearCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command, ct);
        return Ok(data);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Modulo), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<Modulo>> Modificar(int id, [FromBody] ModuloModificarCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command with { Id = id }, ct);
        return Ok(data);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult> Eliminar(int id, CancellationToken ct)
    {
        await sender.Send(new ModuloEliminarCommand(id), ct);
        return NoContent();
    }
}
