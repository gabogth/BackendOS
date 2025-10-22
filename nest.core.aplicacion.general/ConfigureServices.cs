using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using nest.core.aplication.auth;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.General.SexoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.Transaccional;
using nest.core.infraestructura.general;
using nest.core.infraestructura.general.Storage;

namespace nest.core.aplicacion.general
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.general.Mapper.AutomapperProfiles));
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.Configure<AmazonS3StorageOptions>(configuration.GetSection("AdjuntoStorage:AmazonS3"));
            services.AddSingleton<IAmazonS3>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<AmazonS3StorageOptions>>().Value;
                var region = string.IsNullOrWhiteSpace(options.Region) ? RegionEndpoint.USEast1 : RegionEndpoint.GetBySystemName(options.Region);
                var configAmazon = new AmazonS3Config
                {
                    RegionEndpoint = region,
                    ForcePathStyle = options.ForcePathStyle
                };
                if (!string.IsNullOrWhiteSpace(options.ServiceURL))
                    configAmazon.ServiceURL = options.ServiceURL;

                AWSCredentials credentials;
                if (!string.IsNullOrWhiteSpace(options.AccessKey) && !string.IsNullOrWhiteSpace(options.SecretKey))
                    credentials = new BasicAWSCredentials(options.AccessKey, options.SecretKey);
                else
                    credentials = FallbackCredentialsFactory.GetCredentials();

                return new AmazonS3Client(credentials, configAmazon);
            });
            services.AddSingleton<IAdjuntoStorageService, AmazonS3AdjuntoStorageService>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
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
            return services;
        }
    }
}
