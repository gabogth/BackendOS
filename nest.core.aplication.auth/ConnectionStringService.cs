using Microsoft.Extensions.Configuration;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Tenant;
using System.Security.Claims;

namespace nest.core.aplication.auth
{
    public class ConnectionStringService : IConnectionStringService
    {
        public string ConnectionTenant { get; set; }
        public string Engine { get; set; }
        public string Usuario { get; set; }

        private readonly List<Claim> claims;
        private readonly IConfigurationManager configuration;
        public ConnectionStringService(List<Claim> claims, IConfigurationManager configuration)
        {
            this.claims = claims;
            this.configuration = configuration;
        }

        public void Build()
        {
            string ConnectionTenantClave = this.claims.SingleOrDefault(x => x.Type == ClaimTypesCustom.CONNECTION_TENANT).Value;
            this.Usuario = this.claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            if (string.IsNullOrWhiteSpace(ConnectionTenantClave))
                throw new Exception("Usuario no logeadox");
            else
            {
                this.ConnectionTenant = configuration.GetSection("Connections").GetSection(ConnectionTenantClave).GetValue<string>("ConnectionString");
                this.Engine = configuration.GetSection("Connections").GetSection(ConnectionTenantClave).GetValue<string>("Engine");
            }
        }
    }
}
