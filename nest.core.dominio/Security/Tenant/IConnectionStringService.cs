using Microsoft.Extensions.Configuration;

namespace nest.core.dominio.Security.Tenant
{
    public interface IConnectionStringService
    {
        string Usuario { get; }
        string Engine { get; }
        RequestParameters Request { get; }
        IConfigurationManager Configuration { get; set; }
        string ConnectionString { get; }
    }
}
