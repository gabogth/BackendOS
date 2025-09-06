using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            optionsBuilder.UseSqlServer(connectionString, b =>
            {
                b.MigrationsAssembly("nest.core.security");
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
