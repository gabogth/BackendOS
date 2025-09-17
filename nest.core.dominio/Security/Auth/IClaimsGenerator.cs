using System.Security.Claims;

namespace nest.core.dominio.Security.Auth
{
    public interface IClaimsGenerator
    {
        CustomAccessTokenResponse build(ApplicationUser User, List<Claim> aditionalClaims, int? empresaId, string Key, string Issuer, string Audience);
    }
}
