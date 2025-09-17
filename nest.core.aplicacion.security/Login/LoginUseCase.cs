using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infrastructura.utils.Excepciones;
using System.Security.Claims;

namespace nest.core.aplicacion.security.Login
{
    public class LoginUseCase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IClaimsGenerator claimsGenerator;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IEmailSender sender;
        private readonly IUsuarioEmpresaRepository usuarioEmpresaRepository;
        public LoginUseCase(SignInManager<ApplicationUser> signInManager, IClaimsGenerator claimsGenerator, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmailSender sender, IUsuarioEmpresaRepository usuarioEmpresaRepository) 
        {
            this.signInManager = signInManager;
            this.claimsGenerator = claimsGenerator;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.sender = sender;
            this.usuarioEmpresaRepository = usuarioEmpresaRepository;
        }

        public async Task<CustomAccessTokenResponse> Execute(LoginDto login) 
        {
            signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            ApplicationUser user = await signInManager.UserManager.FindByEmailAsync(login.Email);
            if (user == null)
                throw new LoginFailedUserNameException();
            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                List<Claim> claims = await this.GetRoleClaims(user);
                UsuarioEmpresa userClaim = await this.usuarioEmpresaRepository.ObtenerSeleccionado(user.Id);
                CustomAccessTokenResponse response = this.claimsGenerator.build(user, claims, (userClaim == null ? null : userClaim.EmpresaId), this.configuration["Jwt:Key"], this.configuration["Jwt:Issuer"], this.configuration["Jwt:Audience"]);
                var resultToken = await userManager.SetAuthenticationTokenAsync(user, "onPremises", "AccessToken", response.AccessToken);
                if(resultToken.Succeeded)
                    await userManager.SetAuthenticationTokenAsync(user, "onPremises", "RefreshToken", response.RefreshToken);
                return response;
            }
            else
                throw new LoginFailedPasswordException();
        }

        public async Task<CustomAccessTokenResponse> CambiarEmpresa(CambiarEmpresaDto entity)
        {
            signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            ApplicationUser user = await signInManager.UserManager.FindByEmailAsync(entity.Email);
            List<Claim> claims = await this.GetRoleClaims(user);
            await this.usuarioEmpresaRepository.Seleccionar(entity.EmpresaId, user.Id);
            CustomAccessTokenResponse response = this.claimsGenerator.build(user, claims, entity.EmpresaId, this.configuration["Jwt:Key"], this.configuration["Jwt:Issuer"], this.configuration["Jwt:Audience"]);
            var resultToken = await userManager.SetAuthenticationTokenAsync(user, "onPremises", "AccessToken", response.AccessToken);
            if (resultToken.Succeeded)
                await userManager.SetAuthenticationTokenAsync(user, "onPremises", "RefreshToken", response.RefreshToken);
            return response;
        }

        public async Task<List<Claim>> GetRoleClaims(ApplicationUser user)
        {
            IList<string> roles = await this.userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (string roleName in roles)
            {
                var role = await this.roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var claims = await this.roleManager.GetClaimsAsync(role);
                    roleClaims.AddRange(claims);
                }
            }
            return roleClaims;
        }
    }
}
