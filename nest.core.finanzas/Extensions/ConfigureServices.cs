using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.finanzas;
using nest.core.aplicacion.finanzas.CuentaCorriente.Commands;
using nest.core.aplicacion.finanzas.OrigenFinancieroServices;
using nest.core.aplicacion.finanzas.PuntoFinancieroServices;
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
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CuentaCorrienteCrearCommand).Assembly);
            });
            services.AddScoped<OrigenFinancieroService>();
            services.AddScoped<PuntoFinancieroService>();
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
