using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.patrimonial.Activos.Behaviors;
using nest.core.aplicacion.patrimonial.Mapper;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.aplication.auth;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.patrimonial;

namespace nest.core.aplicacion.patrimonial
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.ConfigureValidation(configuration);
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<IActivoRepository, ActivoRepository>();
            services.AddTransient<IUbicacionActivoRepository, UbicacionActivoRepository>();
            services.AddTransient<IUbicacionTecnicaRepository, UbicacionTecnicaRepository>();
            return services;
        }
        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(ActivoCrearValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(ActivoCrearValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
