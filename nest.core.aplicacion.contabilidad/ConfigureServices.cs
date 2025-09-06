using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.contabilidad;

namespace nest.core.aplicacion.contabilidad
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.contabilidad.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<ICuentaContableTipoRepository, CuentaContableTipoRepository>();
            services.AddTransient<ICuentaContableRepository, CuentaContableRepository>();
            return services;
        }
    }
}
