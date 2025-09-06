using nest.core.aplicacion.finanzas;
using nest.core.aplicacion.finanzas.CuentaCorrienteServices;
using nest.core.aplicacion.finanzas.EntidadFinancieraServices;
using nest.core.aplicacion.finanzas.MonedaServices;
using nest.core.aplicacion.finanzas.OrigenFinancieroServices;
using nest.core.aplicacion.finanzas.PuntoFinancieroServices;
using nest.core.aplicacion.finanzas.TerceroServices;
using nest.core.aplicacion.finanzas.FinancieroServices;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.finanzas.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            ConfigureCache(services, configuration);
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<CuentaCorrienteService>();
            services.AddScoped<EntidadFinancieraService>();
            services.AddScoped<MonedaService>();
            services.AddScoped<OrigenFinancieroService>();
            services.AddScoped<PuntoFinancieroService>();
            services.AddScoped<TerceroService>();
            services.AddScoped<FinancieroService>();
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
