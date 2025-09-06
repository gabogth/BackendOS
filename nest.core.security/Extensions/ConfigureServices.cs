using nest.core.aplicacion.security;
using nest.core.aplicacion.security.Aplicacion;
using nest.core.aplicacion.security.Corporativo;
using nest.core.aplicacion.security.Login;
using nest.core.aplicacion.security.Security;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.security.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            ConfigureCache(services, configuration);
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<LoginUseCase>();
            services.AddScoped<ModuloService>();
            services.AddScoped<FormularioService>();
            services.AddScoped<EmpresaService>();
            services.AddScoped<RoleService>();
            services.AddScoped<RoleClaimsService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<RoleUsuarioService>();
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
