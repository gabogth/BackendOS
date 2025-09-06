using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplication.auth;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.SexoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.general;

namespace nest.core.aplicacion.general
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(infraestructura.general.Mapper.AutomapperProfiles));
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
            services.AddTransient<IProvinciaRepository, ProvinciaRepository>();
            services.AddTransient<IDistritoRepository, DistritoRepository>();
            services.AddTransient<IDocumentoIdentidadTipoRepository, DocumentoIdentidadTipoRepository>();
            services.AddTransient<IDocumentoTipoRepository, DocumentoTipoRepository>();
            services.AddTransient<ILicenciaConducirRepository, LicenciaConducirRepository>();
            services.AddTransient<IPaisRepository, PaisRepository>();
            services.AddTransient<ISexoRepository, SexoRepository>();
            return services;
        }
    }
}
