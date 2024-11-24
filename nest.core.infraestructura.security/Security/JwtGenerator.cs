using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.infraestructura.security.Security
{
    public class JwtGenerator : IClaimsGenerator
    {
        public CustomAccessTokenResponse build(ApplicationUser User, List<Claim> aditionalClaims, string tenantId, string Key, string Issuer, string Audience)
        {
            List<Claim> claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Sub, User.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypesCustom.CONNECTION_TENANT, tenantId),
                new Claim(ClaimTypes.Name, User.UserName)
            };
            if(aditionalClaims != null && aditionalClaims.Count > 0)
                claims.AddRange(aditionalClaims);
            SymmetricSecurityKey simetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            SigningCredentials creds = new SigningCredentials(simetricKey, SecurityAlgorithms.HmacSha256);
            DateTime fechaExpiracion = DateTime.Now.AddDays(1).AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: fechaExpiracion,
                signingCredentials: creds
            );
            CustomAccessTokenResponse response = new CustomAccessTokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = buildRefresh(),
                ExpiresIn = (long)(fechaExpiracion - DateTime.Now).TotalSeconds,
                TokenType = "Bearer"
            };
            return response;
        }

        public string buildRefresh()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
