using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Corporativo;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.corporativo;

namespace nest.core.aplicacion.corporativo;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddAutoMapper(typeof(infraestructura.corporativo.Mapper.AutomapperProfiles));
        services.AddTransient<IConnectionStringService>(sp => AuthClaim.constructClaimsAuth(sp, configuration));
        services.AddTransient<IEstructuraOrganizacionalTipoRepository, EstructuraOrganizacionalTipoRepository>();
        return services;
    }
}
