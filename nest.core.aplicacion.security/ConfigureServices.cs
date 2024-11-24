using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.dominio.Security.Auth;
using nest.core.infraestructura.security;
using nest.core.infraestructura.security.Security;
using nest.core.infraestructura.security.Aplicacion;
using nest.core.dominio.Aplicacion.Modulo.Repository;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.infraestructura.security.Corporativo;
using nest.core.aplication.auth;

namespace nest.core.aplicacion.security
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration) 
        {
            services.AddTransient<IEmailSender>(provider =>
            {
                return new EmailSender(
                    configuration["EmailSettings:SmtpServer"] ?? "",
                    int.Parse(configuration["EmailSettings:Port"] ?? "0"),
                    configuration["EmailSettings:UserName"] ?? "",
                    configuration["EmailSettings:Password"] ?? "",
                    configuration["EmailSettings:MailFrom"] ?? "",
                    configuration["EmailSettings:MailFromDisplay"] ?? ""
                );
            });
            services.AddAutoMapper(typeof(infraestructura.security.Mapper.AutomapperProfiles));
            services.AddTransient<IClaimsGenerator, JwtGenerator>();
            services.AddTransient<IModuloRepository, ModuloRepository>();
            services.AddTransient<IFormularioRepository, FormularioRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IConnectionStringService>((serviceProvider) => AuthClaim.constructClaimsAuth(serviceProvider, configuration));
            return services;
        }
    }
}
