using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.corporativo;

namespace nest.core.aplicacion.corporativo
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.corporativo.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>((provider) => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<IEstructuraOrganizacionalTipoRepository, EstructuraOrganizacionalTipoRepository>();
            services.AddTransient<IEstructuraOrganizacionalRepository, EstructuraOrganizacionalRepository>();

            return services;
        }
    }
}
