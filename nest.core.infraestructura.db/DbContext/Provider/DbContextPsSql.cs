using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using nest.core.dominio.Security.Tenant;
using Npgsql;

namespace nest.core.infraestructura.db.DbContext.Provider
{
    public class DbContextPsSql : NestDbContext
    {
        public DbContextPsSql(DbContextOptions<DbContextPsSql> options, IConnectionStringService connectionStringService) : base(options, connectionStringService)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddConsole()
                    .SetMinimumLevel(LogLevel.Debug); // máximo detalle
            });
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning))
                .EnableSensitiveDataLogging();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            NpgsqlLoggingConfiguration.InitializeLogging(loggerFactory, parameterLoggingEnabled: true);
            string connectionString = connectionStringService.Configuration.GetValue<string>($"Connections:Npgsql");
            optionsBuilder.UseNpgsql(connectionString, b => {
                b.MigrationsAssembly("nest.core.driver.postgres");
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
