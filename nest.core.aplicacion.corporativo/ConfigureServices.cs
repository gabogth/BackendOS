using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.corporativo.Empresas.Behaviors;
using nest.core.aplicacion.corporativo.Mapper;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.aplication.auth;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.corporativo;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.security.Security;

namespace nest.core.aplicacion.corporativo
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.ConfigureValidation(configuration);
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>((provider) => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<IEstructuraOrganizacionalTipoRepository, EstructuraOrganizacionalTipoRepository>();
            services.AddTransient<IEstructuraOrganizacionalRepository, EstructuraOrganizacionalRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IUsuarioEmpresaRepository, UsuarioEmpresaRepository>();

            return services;
        }

        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(EmpresaCrearValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(EmpresaCrearValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
