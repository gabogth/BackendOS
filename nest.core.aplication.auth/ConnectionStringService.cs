using Microsoft.Extensions.Configuration;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Tenant;
using System.Security.Claims;

namespace nest.core.aplication.auth
{
    public class ConnectionStringService : IConnectionStringService
    {
        public string ConnectionTenantKey { get; set; }
        public string ConnectionTenant { get; set; }
        public string Engine { get; set; }
        public string Usuario { get; set; }
        public RequestParameters Request { get; set; }

        private readonly List<Claim> claims;
        private readonly IConfigurationManager configuration;
        public ConnectionStringService(List<Claim> claims, IConfigurationManager configuration, RequestParameters request)
        {
            this.claims = claims;
            this.configuration = configuration;
            this.Request = request;
        }

        public void Build()
        {
            string ConnectionTenantClave = this.claims.SingleOrDefault(x => x.Type == ClaimTypesCustom.CONNECTION_TENANT).Value;
            this.Usuario = this.claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            if (string.IsNullOrWhiteSpace(ConnectionTenantClave))
                throw new Exception("Usuario no logeadox");
            else
            {
                ConnectionTenantKey = ConnectionTenantClave;
                ConnectionTenant = configuration.GetValue<string>($"Connections:{ConnectionTenantClave}:ConnectionString");
                Engine = configuration.GetValue<string>($"Connections:{ConnectionTenantClave}:Engine");
            }
        }
    }
}
