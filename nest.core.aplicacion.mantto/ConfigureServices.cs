using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.mantto.Labores.Behaviors;
using nest.core.aplicacion.mantto.Mapper;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.aplication.auth;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.mantto;
using nest.core.infraestructura.mantto.Extensiones;

namespace nest.core.aplicacion.mantto
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.ConfigureValidation(configuration);
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            services.AddTransient<ILaborRepository, LaborRepository>();
            services.AddTransient<IMantenimientoTipoRepository, MantenimientoTipoRepository>();
            services.AddTransient<IOrdenServicioCabeceraRepository, OrdenServicioCabeceraRepository>();
            services.AddTransient<IOrdenServicioMantenimientoExternoRepository, OrdenServicioMantenimientoExternoRepository>();
            services.AddTransient<IOrdenServicioTipoRepository, OrdenServicioTipoRepository>();
            services.AddTransient<IOrdenTrabajoCabeceraRepository, OrdenTrabajoCabeceraRepository>();
            services.AddTransient<IOrdenTrabajoHorarioRepository, OrdenTrabajoHorarioRepository>();
            services.AddTransient<IOrdenTrabajoDetalleRepository, OrdenTrabajoDetalleRepository>();
            services.AddTransient<IOrdenTrabajoPersonalRepository, OrdenTrabajoPersonalRepository>();
            services.AddTransient<IOrdenTrabajoDetalleActivoRepository, OrdenTrabajoDetalleActivoRepository>();
            services.AddTransient<IOrdenServicioCabecera_MantenimientoExternoRepository, OrdenServicioCabecera_MantenimientoExternoRepository>();
            services.AddTransient<IOrdenTrabajoCabecera_MantenimientoExternoRepository, OrdenTrabajoCabecera_MantenimientoExternoRepository>();
            return services;
        }
        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(LaborCrearValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(LaborCrearValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
