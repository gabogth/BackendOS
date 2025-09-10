using Microsoft.Extensions.Configuration;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Tenant;
using System.Security.Claims;

namespace nest.core.aplication.auth
{
    public class ConnectionStringService : IConnectionStringService
    {
        public string Engine { get; set; }
        public string Usuario { get; set; }
        public RequestParameters Request { get; set; }
        public IConfigurationManager Configuration { get; set; }
        public string ConnectionString { get { return Configuration.GetConnectionString("DefaultConnection"); } }

        private readonly List<Claim> Claims;
        public ConnectionStringService(List<Claim> claims, RequestParameters request, IConfigurationManager Configuration)
        {
            this.Claims = claims;
            this.Request = request;
            this.Configuration = Configuration;
            this.Usuario = this.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }
    }
}
