using Microsoft.IdentityModel.Tokens;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace nest.core.infraestructura.security.Security
{
    public class JwtGenerator : IClaimsGenerator
    {
        public CustomAccessTokenResponse build(ApplicationUser User, List<Claim> aditionalClaims, int? empresaId, string Key, string Issuer, string Audience)
        {
            List<Claim> claims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, User.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, User.UserName)
            };
            if (empresaId.HasValue)
                claims.Add(new Claim(ClaimTypesCustom.EMPRESAID, empresaId.ToString()));
            if (aditionalClaims != null && aditionalClaims.Count > 0)
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
