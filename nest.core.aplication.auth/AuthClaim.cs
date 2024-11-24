using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.dominio.Security;
using System.Security.Claims;

namespace nest.core.aplication.auth
{
    public static class AuthClaim
    {
        public static ConnectionStringService constructClaimsAuth(IServiceProvider serviceProvider, IConfigurationManager configuration)
        {
            List<Claim> claims = new List<Claim>();
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var isMigration = Environment.GetCommandLineArgs().FirstOrDefault(x => x == "migrations" || x == "database");
            if (isMigration == null)
            {
                string tenantConnection = httpContextAccessor.HttpContext.Request.Headers["x-action-login"];
                if (!string.IsNullOrWhiteSpace(tenantConnection))
                    claims.Add(new Claim(ClaimTypesCustom.CONNECTION_TENANT, tenantConnection));
                else
                    claims = httpContextAccessor.HttpContext.User.Claims.ToList();
            }
            else
            {
                string section = configuration.GetSection("Migrations").GetValue<string>("SelectedDb");
                claims.Add(new Claim(ClaimTypesCustom.CONNECTION_TENANT, section));
            }
            return new ConnectionStringService(claims, configuration);
        }
    }
}
