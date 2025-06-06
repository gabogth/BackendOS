using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.legal;

namespace nest.core.aplicacion.legal
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.legal.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            services.AddTransient<IContratoTipoRepository, ContratoTipoRepository>();
            services.AddTransient<IContratoCabeceraRepository, ContratoCabeceraRepository>();
            return services;
        }
    }
}
