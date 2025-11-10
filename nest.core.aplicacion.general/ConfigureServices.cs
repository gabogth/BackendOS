using Amazon.S3;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.general.Adjuntos.Behaviors;
using nest.core.aplicacion.general.Mapper;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.aplicacion.utils.Mapper;
using nest.core.aplication.auth;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.General.SexoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.general;
using nest.core.infraestructura.general.Extensiones;
using nest.core.infraestructura.general.Storage;

namespace nest.core.aplicacion.general
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles), typeof(DbMapperProfile));
            services.ConfigureValidation(configuration);
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
            services.AddSingleton<IAdjuntoStorageService, AmazonS3AdjuntoStorageService>();
            services.AddSingleton<IAdjuntoStorageService, LocalFileAdjuntoStorageService>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IPersonaAdjuntosUseCaseRepository, PersonaAdjuntosRepository>();
            services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
            services.AddTransient<IProvinciaRepository, ProvinciaRepository>();
            services.AddTransient<IDistritoRepository, DistritoRepository>();
            services.AddTransient<IDocumentoIdentidadTipoRepository, DocumentoIdentidadTipoRepository>();
            services.AddTransient<IDocumentoTipoRepository, DocumentoTipoRepository>();
            services.AddTransient<ILicenciaConducirRepository, LicenciaConducirRepository>();
            services.AddTransient<IPaisRepository, PaisRepository>();
            services.AddTransient<ISexoRepository, SexoRepository>();
            services.AddTransient<IAdjuntoRepository, AdjuntoRepository>();
            services.AddTransient<IAdjuntoConfigProviderRepository, AdjuntoConfigProviderRepository>();
            services.AddTransient<IAdjuntoTipoRepository, AdjuntoTipoRepository>();
            services.AddTransient<IPersonaAdjuntoRepository, PersonaAdjuntoRepository>();
            return services;
        }
        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(AdjuntoCrearValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(AdjuntoCrearValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
