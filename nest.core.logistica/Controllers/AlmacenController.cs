using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.aplicacion.logistica.Almacenes.Queries;
using nest.core.dominio;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.logistica.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class AlmacenController : ControllerBase
{
    private readonly ISender sender;

    public AlmacenController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Almacen>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<List<Almacen>>> ObtenerTodos(CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerAlmacenesQuery(), ct);
        return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Almacen), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<Almacen>> ObtenerPorId(int id, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerAlmacenPorIdQuery(id), ct);
        return Ok(data);
    }

    [HttpGet("activos")]
    [ProducesResponseType(typeof(List<Almacen>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<List<Almacen>>> ObtenerActivos(CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerAlmacenesActivosQuery(), ct);
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Almacen), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<Almacen>> Agregar([FromBody] AlmacenCrearCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command, ct);
        return Ok(data);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Almacen), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<Almacen>> Modificar(int id, [FromBody] AlmacenModificarCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command with { Id = id }, ct);
        return Ok(data);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult> Eliminar(int id, CancellationToken ct)
    {
        await sender.Send(new AlmacenEliminarCommand(id), ct);
        return Ok(true);
    }
}
