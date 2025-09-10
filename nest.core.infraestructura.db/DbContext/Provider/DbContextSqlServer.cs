using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using nest.core.dominio.Security.Tenant;

namespace nest.core.infraestructura.db.DbContext.Provider
{
    public class DbContextSqlServer: NestDbContext
    {
        public DbContextSqlServer(DbContextOptions<DbContextSqlServer> options, IConnectionStringService connectionStringService) : base(options, connectionStringService)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
            string connectionString = connectionStringService.Configuration.GetValue<string>($"Connections:SqlServer");
            optionsBuilder.UseSqlServer(connectionString, b =>
            {
                b.MigrationsAssembly("nest.core.driver.sqlserver");
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
