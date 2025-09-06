using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.mantto;

namespace nest.core.aplicacion.mantto
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.mantto.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            services.AddTransient<ILaborRepository, LaborRepository>();
            services.AddTransient<IMantenimientoTipoRepository, MantenimientoTipoRepository>();
            services.AddTransient<IOrdenServicioTipoRepository, OrdenServicioTipoRepository>();
            return services;
        }
    }
}
