using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.aplicacion.security.Corporativo;
using nest.core.dominio;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.security.Controllers
{
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

        [HttpGet]
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
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Empresa> ObtenerPorId(byte id)
        {
            try
            {
                return Ok(this.service.ObtenerPorId(id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }

        [HttpGet("activos")]
        public ActionResult<List<Empresa>> ObtenerPorId()
        {
            try
            {
                return Ok(this.service.ObtenerActivos());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ErrorMessage { Server = true, Message = ex.Message });
            }
        }
    }
}
