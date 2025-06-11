using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.general;
using nest.core.aplicacion.general.DepartamentoServices;
using nest.core.aplicacion.general.DistritoServices;
using nest.core.aplicacion.general.DocumentoIdentidadTipoServices;
using nest.core.aplicacion.general.DocumentoTipoServices;
using nest.core.aplicacion.general.LicenciaConducirServices;
using nest.core.aplicacion.general.PaisServices;
using nest.core.aplicacion.general.PersonaServices;
using nest.core.aplicacion.general.ProvinciaServices;
using nest.core.aplicacion.general.SexoServices;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.general.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            ConfigureCache(services, configuration);
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<DepartamentoService>();
            services.AddScoped<DistritoService>();
            services.AddScoped<DocumentoIdentidadTipoService>();
            services.AddScoped<DocumentoTipoService>();
            services.AddScoped<LicenciaConducirService>();
            services.AddScoped<PaisService>();
            services.AddScoped<PersonaService>();
            services.AddScoped<ProvinciaService>();
            services.AddScoped<SexoService>();
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
