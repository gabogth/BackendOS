using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.dominio.Security.Auth;
using nest.core.view.main.Models;
using System;

namespace nest.core.view.main.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddHttpClient<RequestRestApi>(options => {
                options.Timeout = TimeSpan.FromSeconds(10);
                options.BaseAddress = new Uri(configuration.GetValue<string>("GatewayUrl"));
            });
            services.AddTransient<IniciarSesionUseCase>();
            services.AddAuthorization(options => {
                foreach (KeyValuePair<string, string> item in FormPoliciesEnum.Policies)
                    options.AddPolicy(item.Value, policy => policy.RequireClaim(item.Value, "true"));
            });
            return services;
        }
    }
}
