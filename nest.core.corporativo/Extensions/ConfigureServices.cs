using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.corporativo;

namespace nest.core.corporativo.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<EstructuraOrganizacionalTipoService>();
            return services;
        }
    }
}
