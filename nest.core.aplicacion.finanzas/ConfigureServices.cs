using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;
using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.finanzas;

namespace nest.core.aplicacion.finanzas
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.finanzas.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<ICuentaCorrienteRepository, CuentaCorrienteRepository>();
            services.AddTransient<IEntidadFinancieraRepository, EntidadFinancieraRepository>();
            services.AddTransient<IMonedaRepository, MonedaRepository>();
            services.AddTransient<IOrigenFinancieroRepository, OrigenFinancieroRepository>();
            services.AddTransient<IPuntoFinancieroRepository, PuntoFinancieroRepository>();
            services.AddTransient<ITerceroRepository, TerceroRepository>();
            services.AddTransient<IFinancieroRepository, FinancieroRepository>();
            return services;
        }
    }
}
