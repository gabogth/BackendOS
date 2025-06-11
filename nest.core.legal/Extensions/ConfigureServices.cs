using nest.core.aplicacion.legal;
using nest.core.aplicacion.legal.ContratoServices;
using nest.core.aplicacion.legal.ContratoTipoServices;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.legal.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            ConfigureCache(services, configuration);
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<ContratoTipoService>();
            services.AddScoped<ContratoPersonalService>();
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
