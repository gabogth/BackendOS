using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nest.core.view.main.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UtilController : Controller
    {
        [HttpPost("actionlink")]
        public ActionResult<Dictionary<string, string>> ActionLink([FromBody] string[] acciones)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            for (int i = 0; i < acciones.Length; i++)
            {
                string controlador = acciones[i].Split('.')[0];
                string accion = acciones[i].Split('.')[1];
                results.Add($"{acciones[i]}", Url.ActionLink(accion, controlador));
            }
            return results;
        }
    }
}
