using FluentValidation;
using MediatR;
using nest.core.aplicacion.rrhh;
using nest.core.aplicacion.rrhh.Cargos.Behaviors;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajoServices;
using nest.core.aplicacion.rrhh.HorarioServices;
using nest.core.aplicacion.rrhh.RegistroAsistenciaServices;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajoServices;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticaServices;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.rrhh.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            ConfigureCache(services, configuration);
            services.ConfigureInfraestructura(configuration);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CargoCrearCommand).Assembly);
            });
            services.AddValidatorsFromAssemblyContaining<CargoCrearValidator>();
            services.AddScoped<GrupoTrabajoService>();
            services.AddScoped<HorarioService>();
            services.AddScoped<RegistroAsistenciaService>();
            services.AddScoped<RegistroAsistenciaOrdenTrabajoService>();
            services.AddScoped<RegistroAsistenciaPoliticaService>();
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
