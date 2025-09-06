using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using nest.core.dominio.Security.Tenant;

namespace nest.core.infraestructura.db.DbContext.Provider
{
    public class DbContextPsSql : NestDbContext
    {
        public DbContextPsSql(DbContextOptions<DbContextPsSql> options, IConnectionStringService connectionStringService) : base(options, connectionStringService)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.UseNpgsql(connectionString, b => {
                b.MigrationsAssembly("nest.core.security");
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
