using Amazon.Lambda;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.aplicacion.iclock.Marcaciones.Behaviors;
using nest.core.aplicacion.iclock.Services;
using nest.core.aplicacion.iclock.Services.Interfaces;
using nest.core.aplicacion.utils.Behaviors;
using nest.core.aplication.auth;
using nest.core.dominio.Security.Tenant;

namespace nest.core.aplicacion.iclock
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureInfraestructura(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.ConfigureValidation(configuration);
            services.AddTransient<IConnectionStringService>(provider => AuthClaim.constructClaimsAuth(provider, configuration));
            //if (Environment.GetEnvironmentVariable("IS_LAMBDA") != null)
            //{
            //    services.AddAWSService<IAmazonLambda>(new Amazon.Extensions.NETCore.Setup.AWSOptions
            //    {
            //        Region = Amazon.RegionEndpoint.USEast1
            //    });
            //    services.AddTransient<ILambdaInvocationService, LambdaInvocationService>();
            //    services.AddTransient<IMarcaRegistrar, MarcaRegistrarServiceLambda>();
            //}
            //else
            services.AddTransient<IMarcaRegistrar, MarcaRegistrarServiceApiRest>();
            return services;
        }

        private static void ConfigureValidation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddValidatorsFromAssembly(typeof(RecibirMarcacionesValidator).Assembly);
            services.AddMediatR(cnf => {
                cnf.RegisterServicesFromAssemblyContaining(typeof(RecibirMarcacionesValidator));
                cnf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
