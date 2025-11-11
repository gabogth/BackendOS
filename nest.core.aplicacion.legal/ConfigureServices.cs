using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.legal.ContratoTipos.Behaviors;
using nest.core.aplicacion.legal.Mapper;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.aplication.auth;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.legal;

namespace nest.core.aplicacion.legal
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.ConfigureValidation(configuration);
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            services.AddTransient<IContratoTipoRepository, ContratoTipoRepository>();
            services.AddTransient<IContratoPersonalRepository, ContratoPersonalRepository>();
            return services;
        }
        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(ContratoTipoCrearValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(ContratoTipoCrearValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
