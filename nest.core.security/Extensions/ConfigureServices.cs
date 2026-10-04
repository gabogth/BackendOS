using FluentValidation;
using MediatR;
using nest.core.aplicacion.contabilidad.CuentaContables.Behaviors;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;
using nest.core.aplicacion.corporativo.Empresas.Behaviors;
using nest.core.aplicacion.corporativo.Empresas.Commands;
using nest.core.aplicacion.costos.CentroCostos.Behaviors;
using nest.core.aplicacion.costos.CentroCostos.Commands;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Behaviors;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Commands;
using nest.core.aplicacion.general.Departamentos.Behaviors;
using nest.core.aplicacion.general.Departamentos.Commands;
using nest.core.aplicacion.iclock.Marcaciones.Behaviors;
using nest.core.aplicacion.iclock.Marcaciones.Commands;
using nest.core.aplicacion.legal.ContratoTipos.Behaviors;
using nest.core.aplicacion.legal.ContratoTipos.Commands;
using nest.core.aplicacion.logistica.Almacenes.Behaviors;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.aplicacion.mantto.Labores.Behaviors;
using nest.core.aplicacion.mantto.Labores.Commands;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Behaviors;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;
using nest.core.aplicacion.rrhh.Cargos.Behaviors;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.aplicacion.security.Formularios.Behaviors;
using nest.core.aplicacion.security.Formularios.Commands;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.Cache;

namespace nest.core.security.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            ConfigureCache(services, configuration);
            aplicacion.security.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.contabilidad.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.corporativo.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.costos.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.finanzas.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.general.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.iclock.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.legal.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.logistica.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.mantto.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.patrimonial.ConfigureServices.ConfigureInfraestructura(services, configuration);
            aplicacion.rrhh.ConfigureServices.ConfigureInfraestructura(services, configuration);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(FormularioCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CuentaContableCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmpresaCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CentroDeCostosCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CuentaCorrienteCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DepartamentoCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RecibirMarcacionesCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ContratoTipoCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AlmacenCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LaborCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UbicacionActivoCrearCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CargoCrearCommand).Assembly));
            services.AddValidatorsFromAssemblyContaining<FormularioCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<CuentaContableCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<EmpresaCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<CentroDeCostosCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<CuentaCorrienteCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<DepartamentoCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<RecibirMarcacionesValidator>();
            services.AddValidatorsFromAssemblyContaining<ContratoTipoCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<AlmacenCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<LaborCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<UbicacionActivoCrearValidator>();
            services.AddValidatorsFromAssemblyContaining<CargoCrearValidator>();
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
