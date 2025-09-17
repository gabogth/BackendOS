using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using nest.core.dominio.Security.Tenant;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace nest.core.infraestructura.db.DbContext.Provider
{
    public class DbContextMySql : NestDbContext
    {
        public DbContextMySql(DbContextOptions<DbContextMySql> options, IConnectionStringService connectionStringService) : base(options, connectionStringService)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
            string connectionString = connectionStringService.Configuration.GetValue<string>($"Connections:MySql");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), my =>
            {
                my.MigrationsAssembly("nest.core.driver.mysql");
                my.SchemaBehavior(
                    MySqlSchemaBehavior.Translate,
                    (schema, name) => $"{schema}_{name}"
                );
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
