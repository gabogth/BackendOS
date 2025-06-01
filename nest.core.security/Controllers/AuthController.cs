using nest.core.aplicacion.security.Login;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;

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
                return BadRequest(ex.Message);
            }
        }
    }
}
