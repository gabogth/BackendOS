using nest.core.aplicacion.rrhh;
using nest.core.aplicacion.rrhh.CargoServices;
using nest.core.aplicacion.rrhh.GrupoHorarioServices;

namespace nest.core.rrhh.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<CargoService>();
            services.AddScoped<GrupoHorarioService>();
            return services;
        }
    }
}
