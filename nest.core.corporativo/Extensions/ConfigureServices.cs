using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.corporativo;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalServices;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipoServices;

namespace nest.core.corporativo.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<EstructuraOrganizacionalTipoService>();
            services.AddScoped<EstructuraOrganizacionalService>();
          
            return services;
        }
    }
}
