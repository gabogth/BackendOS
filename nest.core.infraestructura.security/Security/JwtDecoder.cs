using nest.core.dominio.Security.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.infraestructura.security.Security
{
    public class JwtDecoder: IJwtDecoder
    {
        public List<Claim> decompiler(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
                return handler.ReadJwtToken(token).Claims.ToList();
            else throw new Exception("El token no es legible.");
        }
    }
}
