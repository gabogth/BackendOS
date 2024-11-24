using System.Security.Claims;

namespace nest.core.dominio.Security.Auth
{
    public interface IClaimsGenerator
    {
        CustomAccessTokenResponse build(ApplicationUser User, List<Claim> aditionalClaims, string tenantId, string Key, string Issuer, string Audience);
    }
}
