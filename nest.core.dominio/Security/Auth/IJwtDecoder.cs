using System.Security.Claims;

namespace nest.core.dominio.Security.Auth
{
    public interface IJwtDecoder
    {
        List<Claim> decompiler(string token);
    }
}
