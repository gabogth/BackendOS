using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nest.core.dominio.Security.Auth;

namespace nest.core.view.main.Controllers
{
    [Authorize]
    public class SeguridadController : Controller
    {
        [Authorize(Policy = FormPoliciesEnum.Seguridad_Index)]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = FormPoliciesEnum.Seguridad_Formulario)]
        public IActionResult Formulario()
        {
            ViewData["Title"] = "Formulario";
            return View();
        }

        [Authorize(Policy = FormPoliciesEnum.Seguridad_Rol)]
        public IActionResult Rol()
        {
            ViewData["Title"] = "Rol";
            return View();
        }

        [Authorize(Policy = FormPoliciesEnum.Seguridad_RolFormulario)]
        public IActionResult RolFormulario()
        {
            ViewData["Title"] = "Rol Formulario";
            return View();
        }

        [Authorize(Policy = FormPoliciesEnum.Seguridad_RolUsuario)]
        public IActionResult RolUsuario()
        {
            ViewData["Title"] = "Rol Usuario";
            return View();
        }

        [Authorize(Policy = FormPoliciesEnum.Seguridad_Usuario)]
        public IActionResult Usuario()
        {
            ViewData["Title"] = "Usuarios";
            return View();
        }
    }
}
