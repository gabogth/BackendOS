using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.general.AdjuntoTipoServices;
using nest.core.dominio;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.general.Controllers
{
    /// <summary>
    /// Controlador para la administración de los tipos de adjuntos.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdjuntoTipoController : ControllerBase
    {
        private readonly AdjuntoTipoService service;
        private readonly ILogger<AdjuntoTipoController> logger;

        public AdjuntoTipoController(AdjuntoTipoService service, ILogger<AdjuntoTipoController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AdjuntoTipo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<AdjuntoTipo>>> ObtenerTodos()
        {
            try
            {
                var data = await service.ObtenerTodos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdjuntoTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoTipo>> ObtenerPorId(AdjuntoTipoEnum id)
        {
            try
            {
                var data = await service.ObtenerPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<AdjuntoTipo>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<AdjuntoTipo>>> ObtenerActivos()
        {
            try
            {
                var data = await service.ObtenerActivos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(AdjuntoTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoTipo>> Agregar([FromBody] AdjuntoTipoCrearDto registro)
        {
            try
            {
                var data = await service.Agregar(registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AdjuntoTipo), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoTipo>> Modificar(AdjuntoTipoEnum id, [FromBody] AdjuntoTipoCrearDto registro)
        {
            try
            {
                var data = await service.Modificar(id, registro);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(AdjuntoTipoEnum id)
        {
            try
            {
                await service.Eliminar(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
