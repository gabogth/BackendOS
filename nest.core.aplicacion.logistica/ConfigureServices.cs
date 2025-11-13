using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.logistica.Mapper;
using nest.core.aplication.auth;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.logistica;

namespace nest.core.aplicacion.logistica
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration) 
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            services.AddTransient<IAlmacenRepository, AlmacenRepository>();
            return services;
        }
    }
}
