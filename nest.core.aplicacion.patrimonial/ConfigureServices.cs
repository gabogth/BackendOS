using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.patrimonial;

namespace nest.core.aplicacion.patrimonial
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.patrimonial.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<IActivoRepository, ActivoRepository>();
            services.AddTransient<IUbicacionActivoRepository, UbicacionActivoRepository>();
            services.AddTransient<IUbicacionTecnicaRepository, UbicacionTecnicaRepository>();
            return services;
        }
    }
}
