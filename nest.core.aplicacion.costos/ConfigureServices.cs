using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Costos.CentroDeCostosEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.costos;

namespace nest.core.aplicacion.costos
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.costos.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>((provider) => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<ICentroDeCostosRepository, CentroDeCostosRepository>();
            return services;
        }
    }
}
