using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;
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
        public LoginUseCase(SignInManager<ApplicationUser> signInManager, IClaimsGenerator claimsGenerator, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmailSender sender) 
        {
            this.signInManager = signInManager;
            this.claimsGenerator = claimsGenerator;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.sender = sender;
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
                CustomAccessTokenResponse response = this.claimsGenerator.build(user, claims, login.TenantId, this.configuration["Jwt:Key"], this.configuration["Jwt:Issuer"], this.configuration["Jwt:Audience"]);
                var resultToken = await userManager.SetAuthenticationTokenAsync(user, "onPremises", "AccessToken", response.AccessToken);
                if(resultToken.Succeeded)
                    await userManager.SetAuthenticationTokenAsync(user, "onPremises", "RefreshToken", response.RefreshToken);
                return response;
            }
            else
                throw new LoginFailedPasswordException();
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
