using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using nest.core.dominio.Security.Auth;
using System.Security.Claims;

namespace nest.core.view.main.Extensions
{
    public class ConfigureSession
    {
        private readonly HttpContext context;
        private readonly IJwtDecoder decoder;
        public ConfigureSession(HttpContext context, IJwtDecoder decoder)
        {
            this.context = context;
            this.decoder = decoder;
        }
        public async Task build(AuthResponse response)
        {
            List<Claim> claims = decoder.decompiler(response.AccessToken);
            claims.Add(new Claim(ClaimTypes.IsPersistent, "true"));
            claims.Add(new Claim(ClaimTypes.UserData, Newtonsoft.Json.JsonConvert.SerializeObject(response)));
            claims.Add(new Claim("AccessToken", response.AccessToken));
            claims.Add(new Claim("RefreshToken", response.RefreshToken));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        public async Task destroy()
        {
            await context.SignOutAsync();
        }
    }
}
