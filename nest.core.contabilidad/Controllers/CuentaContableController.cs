using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.contabilidad.CuentaContableServices;
using nest.core.dominio;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.contabilidad.Controllers
{
    /// <summary>
    /// Controlador para la gestión de cuentas contables.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CuentaContableController : ControllerBase
    {
        private readonly CuentaContableService service;
        private readonly ILogger<CuentaContableController> logger;

        public CuentaContableController(CuentaContableService service, ILogger<CuentaContableController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CuentaContable>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<CuentaContable>>> ObtenerTodos()
        {
            try
            {
                var data = await service.ObtenerTodos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CuentaContable), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<CuentaContable>> ObtenerPorId(int id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<CuentaContable>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<CuentaContable>>> ObtenerActivos()
        {
            try
            {
                var data = await service.ObtenerActivos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CuentaContable), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<CuentaContable>> Agregar([FromBody] CuentaContableCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CuentaContable), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<CuentaContable>> Modificar(int id, [FromBody] CuentaContableCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
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
                return BadRequest(GenerateMessage.Create(ex));
            }
        }
    }
}
