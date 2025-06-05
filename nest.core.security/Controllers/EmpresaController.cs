using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Corporativo;
using nest.core.dominio;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.security.Controllers
{
    /// <summary>
    /// Controlador para la gestión de empresas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        private readonly EmpresaService service;
        private readonly ILogger<EmpresaController> logger;
        public EmpresaController(EmpresaService service, ILogger<EmpresaController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las empresas registradas.
        /// </summary>
        /// <returns>Lista de empresas.</returns>
        /// <response code="200">Empresas obtenidas exitosamente.</response>
        /// <response code="400">Error al obtener las empresas.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Empresa>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public ActionResult<List<Empresa>> ObtenerTodos()
        {
            try
            {
                var data = this.service.ObtenerTodos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        /// <summary>
        /// Obtiene una empresa por su identificador.
        /// </summary>
        /// <param name="id">ID de la empresa.</param>
        /// <returns>Una empresa.</returns>
        /// <response code="200">Empresa encontrada.</response>
        /// <response code="400">Error al obtener la empresa.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Empresa), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public ActionResult<Empresa> ObtenerPorId(byte id)
        {
            try
            {
                return Ok(this.service.ObtenerPorId(id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }

        /// <summary>
        /// Obtiene todas las empresas activas.
        /// </summary>
        /// <returns>Lista de empresas activas.</returns>
        /// <response code="200">Empresas activas obtenidas exitosamente.</response>
        /// <response code="400">Error al obtener las empresas activas.</response>
        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<Empresa>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public ActionResult<List<Empresa>> ObtenerPorId()
        {
            try
            {
                return Ok(this.service.ObtenerActivos());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }
    }
}
