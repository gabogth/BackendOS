using nest.core.aplicacion.logistica;
using nest.core.aplicacion.logistica.AlmacenServices;

namespace nest.core.logistica.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<AlmacenService>();
            return services;
        }
    }
}
