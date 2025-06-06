using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.general;

namespace nest.core.aplicacion.general
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.general.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            return services;
        }
    }
}
