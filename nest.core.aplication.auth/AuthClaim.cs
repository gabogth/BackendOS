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
            if (!MigrationService.IsMigration())
            {
                string tenantConnection = httpContextAccessor.HttpContext.Request.Headers["x-action-login"];
                if (!string.IsNullOrWhiteSpace(tenantConnection))
                    claims.Add(new Claim(ClaimTypesCustom.CONNECTION_TENANT, tenantConnection));
                else
                    claims = httpContextAccessor.HttpContext.User.Claims.ToList();
            }
            else claims.Add(new Claim(ClaimTypesCustom.CONNECTION_TENANT, MigrationService.MigrationConnection()));
            return new ConnectionStringService(claims, configuration);
        }
    }
}
