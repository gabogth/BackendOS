using FluentValidation;
using MediatR;
using nest.core.aplicacion.rrhh;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Behaviors;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.rrhh.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureValidation(configuration);
            services.ConfigureCache(configuration);
            services.ConfigureInfraestructura(configuration);
            return services;
        }

        private static void ConfigureCache(this IServiceCollection services, IConfigurationManager configuration)
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

        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(RegistroAsistenciaOrdenTrabajoCrearUsuarioActualValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(RegistroAsistenciaOrdenTrabajoCrearUsuarioActualValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
