using HotChocolate.Execution.Configuration;
using nest.core.aplicacion.datasource.Querys;
using nest.core.aplication.auth;
using nest.core.dominio.Security.Tenant;

namespace nest.core.datasource.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddTransient<IConnectionStringService>((provider) => AuthClaim.constructClaimsAuth(provider, configuration));
            return services;
        }

        public static IRequestExecutorBuilder AddDataSources(this IRequestExecutorBuilder services)
        {
            services.AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<AplicacionQuery>()
                .AddTypeExtension<ContabilidadQuery>()
                .AddTypeExtension<CorporativoQuery>()
                .AddTypeExtension<CostosQuery>()
                .AddTypeExtension<FinanzasQuery>()
                .AddTypeExtension<GeneralQuery>()
                .AddTypeExtension<LegalQuery>()
                .AddTypeExtension<LogisticaQuery>()
                .AddTypeExtension<ManttoQuery>()
                .AddTypeExtension<PatrimonialQuery>()
                .AddTypeExtension<RRHHQuery>();

            return services;
        }
    }
}
