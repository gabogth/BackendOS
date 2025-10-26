using nest.core.aplicacion.mantto;
using nest.core.aplicacion.mantto.OrdenServicio;
using nest.core.aplicacion.mantto.OrdenTrabajo;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivoServices;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleServices;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonalServices;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.mantto.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            ConfigureCache(services, configuration);
            services.ConfigureInfraestructura(configuration);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(MantenimientoTipoCrearCommand).Assembly);
            });
            services.AddScoped<MantenimientoExternoService>();
            services.AddScoped<OrdenTrabajoMantenimientoExternoService>();
            services.AddScoped<OrdenTrabajoDetalleService>();
            services.AddScoped<OrdenTrabajoPersonalService>();
            services.AddScoped<OrdenTrabajoDetalleActivoService>();
            return services;
        }
        private static void ConfigureCache(IServiceCollection services, IConfigurationManager configuration)
        {
            bool useRedis = configuration.GetValue<bool>($"RedisConfig:Enabled");
            if (useRedis)
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = configuration.GetValue<string>($"RedisConfig:ConnectionString");
                    options.InstanceName = configuration.GetValue<string>($"RedisConfig:InstanceName");
                });
                services.AddScoped<ICacheRepository, RedisCacheRepository>();
            }
            else
            {
                services.AddMemoryCache();
                services.AddScoped<ICacheRepository, MemoryCacheRepository>();
            }
        }
    }
}
