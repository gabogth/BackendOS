using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using nest.core.dominio.Security.Auth;
using nest.core.view.main.Extensions;
using nest.core.view.main.Models;
using System.Text;

namespace nest.core.view.main.Controllers
{
    public class AuthController : Controller
    {
        private readonly IniciarSesionUseCase useCase;
        private readonly ILogger<AuthController> logger;
        private readonly IJwtDecoder decoder;
        public AuthController(IniciarSesionUseCase useCase, ILogger<AuthController> logger, IJwtDecoder decoder)
        {
            this.useCase = useCase;
            this.logger = logger;
            this.decoder = decoder;
        }
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginRequest, string returnUrl)
        {
            try
            {
                AuthResponse response = await useCase.execute(loginRequest);
                ConfigureSession session = new ConfigureSession(HttpContext, decoder);
                await session.build(response);
                if (returnUrl != null && returnUrl.Trim() != string.Empty && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return Redirect("/");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                ViewData["ErrorMessage"] = "Ocurrió un error: " + ex.Message;
                return View(loginRequest);
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                ConfigureSession session = new ConfigureSession(HttpContext, decoder);
                await session.destroy();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return Redirect("/");
        }
    }
}
