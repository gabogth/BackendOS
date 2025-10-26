using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.general;
using nest.core.aplicacion.general.AdjuntoConfigProviderServices;
using nest.core.aplicacion.general.AdjuntoServices;
using nest.core.aplicacion.general.AdjuntoTipoServices;
using nest.core.aplicacion.general.Distritos.Commands;
using nest.core.aplicacion.general.DocumentoIdentidadTipoServices;
using nest.core.aplicacion.general.DocumentoTipoServices;
using nest.core.aplicacion.general.LicenciaConducirServices;
using nest.core.aplicacion.general.PersonaAdjuntoServices;
using nest.core.aplicacion.general.PersonaUseCases;
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
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DistritoCrearCommand).Assembly);
            });
            services.AddScoped<DocumentoIdentidadTipoService>();
            services.AddScoped<DocumentoTipoService>();
            services.AddScoped<LicenciaConducirService>();
            services.AddScoped<PersonaAdjuntosUseCase>();
            services.AddScoped<PersonaAdjuntoService>();
            services.AddScoped<SexoService>();
            services.AddScoped<AdjuntoService>();
            services.AddScoped<AdjuntoTipoService>();
            services.AddScoped<AdjuntoConfigProviderService>();
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
