using nest.core.aplicacion.rrhh;
using nest.core.aplicacion.rrhh.CargoServices;

namespace nest.core.rrhh.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<CargoService>();
            return services;
        }
    }
}
