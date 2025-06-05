using nest.core.aplicacion.legal;
using nest.core.aplicacion.legal.ContratoTipoServices;

namespace nest.core.legal.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<ContratoTipoService>();
            return services;
        }
    }
}
