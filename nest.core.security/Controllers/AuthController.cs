using nest.core.aplicacion.security.Login;
using Microsoft.AspNetCore.Mvc;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;
using nest.core.dominio;

namespace nest.core.security.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly LoginUseCase loginUseCase;
        private readonly ILogger<AuthController> logger;
        public AuthController(LoginUseCase loginUseCase, ILogger<AuthController> logger)
        {
            this.loginUseCase = loginUseCase;
            this.logger = logger;
        }

        /// <summary>
        /// Inicia sesión y genera un token de acceso.
        /// </summary>
        /// <param name="actionLogin">Encabezado que indica el tenant o contexto de acción.</param>
        /// <param name="login">Credenciales del usuario.</param>
        /// <returns>Token de acceso con información del usuario.</returns>
        /// <response code="200">Login exitoso</response>
        /// <response code="400">Error en la solicitud o credenciales incorrectas</response>
        [HttpPost("login")]
        public async Task<ActionResult<CustomAccessTokenResponse>> Login([FromHeader(Name = "x-action-login")] string? actionLogin, [FromBody] LoginDto login)
        {
            try
            {
                CustomAccessTokenResponse token = await loginUseCase.Execute(login);
                return Ok(token);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return BadRequest(GenerateMessage.Create(ex));
            }
        }
    }
}
