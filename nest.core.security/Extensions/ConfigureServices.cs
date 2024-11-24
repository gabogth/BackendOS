using nest.core.aplicacion.security;
using nest.core.aplicacion.security.Aplicacion;
using nest.core.aplicacion.security.Corporativo;
using nest.core.aplicacion.security.Login;
using nest.core.aplicacion.security.Security;

namespace nest.core.security.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureInfraestructura(configuration);
            services.AddScoped<LoginUseCase>();
            services.AddScoped<ModuloService>();
            services.AddScoped<FormularioService>();
            services.AddScoped<EmpresaService>();
            services.AddScoped<RoleService>();
            services.AddScoped<RoleClaimsService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<RoleUsuarioService>();
            return services;
        }
    }
}
