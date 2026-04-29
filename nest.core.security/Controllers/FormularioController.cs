using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Formularios.Commands;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio;
using nest.core.dominio.Aplicacion.Formulario;
using System.Collections.Generic;

namespace nest.core.security.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FormularioController : Controller
{
    private readonly ISender sender;

    public FormularioController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Formulario>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Formulario>>> ObtenerTodos(CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerFormulariosQuery(), ct);
        return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Formulario), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<Formulario>> ObtenerPorId(int id, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerFormularioPorIdQuery(id), ct);
        return Ok(data);
    }

    [HttpGet("modulo/{moduloId}")]
    [ProducesResponseType(typeof(List<Formulario>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Formulario>>> ObtenerPorModuloId(int moduloId, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerFormulariosPorModuloIdQuery(moduloId), ct);
        return Ok(data);
    }

    [HttpPost("filter")]
    [ProducesResponseType(typeof(List<Formulario>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Formulario>>> ObtenerPorFiltro([FromBody] DataSourceLoadOptionsBase options, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerFormulariosPorFiltroQuery(options), ct);
        return Ok(data);
    }

    [HttpPost("filter_activos")]
    [ProducesResponseType(typeof(List<Formulario>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Formulario>>> ObtenerPorFiltroActivos([FromBody] DataSourceLoadOptionsBase options, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerFormulariosPorFiltroActivosQuery(options), ct);
        return Ok(data);
    }

    [HttpGet("rol/{roleId}")]
    [ProducesResponseType(typeof(List<Formulario>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Formulario>>> ObtenerPorRolId(string roleId, CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerFormulariosPorRoleIdQuery(roleId), ct);
        return Ok(data);
    }

    [HttpGet("current_user")]
    [ProducesResponseType(typeof(List<Formulario>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<List<Formulario>>> ObtenerPorUserId(CancellationToken ct)
    {
        var data = await sender.Send(new ObtenerFormularioPorUserIdQuery(), ct);
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Formulario), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<Formulario>> Agregar([FromBody] FormularioCrearCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command, ct);
        return Ok(data);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Formulario), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<Formulario>> Modificar(int id, [FromBody] FormularioModificarCommand command, CancellationToken ct)
    {
        var data = await sender.Send(command with { Id = id }, ct);
        return Ok(data);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult> Eliminar(int id, CancellationToken ct)
    {
        await sender.Send(new FormularioEliminarCommand(id), ct);
        return Ok(true);
    }
}
