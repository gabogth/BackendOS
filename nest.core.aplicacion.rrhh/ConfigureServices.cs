using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.rrhh;

namespace nest.core.aplicacion.rrhh
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.rrhh.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            services.AddTransient<ICargoRepository, CargoRepository>();
            return services;
        }
    }
}
