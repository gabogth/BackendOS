using nest.core.aplicacion.logistica;

namespace nest.core.logistica.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<AlmacenService>();
            services.AddScoped<OrdenServicioCabeceraService>();
            services.AddScoped<OrdenServicioMantenimientoExternoService>();
            return services;
        }
    }
}
