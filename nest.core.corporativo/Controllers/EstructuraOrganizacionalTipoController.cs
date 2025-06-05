using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.dominio;
using nest.core.dominio.Corporativo;
using nest.core.aplicacion.corporativo;

namespace nest.core.corporativo.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class EstructuraOrganizacionalTipoController : ControllerBase
{
    private readonly EstructuraOrganizacionalTipoService service;
    private readonly ILogger<EstructuraOrganizacionalTipoController> logger;

    public EstructuraOrganizacionalTipoController(EstructuraOrganizacionalTipoService service, ILogger<EstructuraOrganizacionalTipoController> logger)
    {
        this.service = service;
        this.logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<EstructuraOrganizacionalTipo>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<List<EstructuraOrganizacionalTipo>>> ObtenerTodos()
    {
        try
        {
            var data = await service.ObtenerTodos();
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EstructuraOrganizacionalTipo), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<EstructuraOrganizacionalTipo>> ObtenerPorId(int id)
    {
        try
        {
            var data = await service.ObtenerPorId(id);
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
        }
    }

    [HttpGet("activos")]
    [ProducesResponseType(typeof(List<EstructuraOrganizacionalTipo>), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<List<EstructuraOrganizacionalTipo>>> ObtenerActivos()
    {
        try
        {
            var data = await service.ObtenerActivos();
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(EstructuraOrganizacionalTipo), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<EstructuraOrganizacionalTipo>> Agregar([FromBody] EstructuraOrganizacionalTipoCrearDto registro)
    {
        try
        {
            var data = await service.Agregar(registro);
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(EstructuraOrganizacionalTipo), 200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult<EstructuraOrganizacionalTipo>> Modificar(int id, [FromBody] EstructuraOrganizacionalTipoCrearDto registro)
    {
        try
        {
            var data = await service.Modificar(id, registro);
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    public async Task<ActionResult> Eliminar(int id)
    {
        try
        {
            await service.Eliminar(id);
            return Ok(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
        }
    }
}
