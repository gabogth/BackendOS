using HotChocolate.Execution.Configuration;
using nest.core.aplicacion.datasource.Querys;

namespace nest.core.datasource.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureAplication(this IServiceCollection services, IConfigurationManager configuration)
        {
            return services;
        }

        public static IRequestExecutorBuilder AddDataSources(this IRequestExecutorBuilder services)
        {
            services.AddQueryType<ContabilidadQuery>();
            return services;
        }
    }
}
