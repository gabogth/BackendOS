using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.costos.CentroCostos.Behaviors;
using nest.core.aplicacion.costos.Mapper;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.aplication.auth;
using nest.core.dominio.Costos.CentroDeCostosEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.costos;
using nest.core.infraestructura.db.Transaccional;

namespace nest.core.aplicacion.costos
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.ConfigureValidation(configuration);
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>((provider) => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<ICentroDeCostosRepository, CentroDeCostosRepository>();
            return services;
        }
        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(CentroDeCostosCrearValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(CentroDeCostosCrearValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
