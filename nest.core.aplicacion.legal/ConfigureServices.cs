using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.aplicacion.legal.Mapper;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.legal;

namespace nest.core.aplicacion.legal
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            services.AddTransient<IContratoTipoRepository, ContratoTipoRepository>();
            services.AddTransient<IContratoPersonalRepository, ContratoPersonalRepository>();
            return services;
        }
    }
}
