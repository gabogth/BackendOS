using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.general;
using nest.core.aplicacion.general.DepartamentoServices;
using nest.core.aplicacion.general.DistritoServices;
using nest.core.aplicacion.general.DocumentoIdentidadTipoServices;
using nest.core.aplicacion.general.DocumentoTipoServices;
using nest.core.aplicacion.general.LicenciaConducirServices;
using nest.core.aplicacion.general.PaisServices;
using nest.core.aplicacion.general.PersonaServices;
using nest.core.aplicacion.general.ProvinciaServices;
using nest.core.aplicacion.general.SexoServices;

namespace nest.core.general.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<DepartamentoService>();
            services.AddScoped<DistritoService>();
            services.AddScoped<DocumentoIdentidadTipoService>();
            services.AddScoped<DocumentoTipoService>();
            services.AddScoped<LicenciaConducirService>();
            services.AddScoped<PaisService>();
            services.AddScoped<PersonaService>();
            services.AddScoped<ProvinciaService>();
            services.AddScoped<SexoService>();
            return services;
        }
    }
}
