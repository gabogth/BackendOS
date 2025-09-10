using Microsoft.EntityFrameworkCore;
using nest.core.infraestructura.db.DbContext.Provider;

namespace nest.core.security.Extensions
{
    public static class MigrationResolver
    {
        public static async Task ExecuteMigration(WebApplication app)
        {
            string connection = Environment.GetEnvironmentVariable("ENGINE");
            switch (connection)
            {
                case "SqlServer":
                    var applicationSql = app.Services.CreateScope().ServiceProvider.GetRequiredService<DbContextSqlServer>();
                    var pendingMigrationsSql = await applicationSql.Database.GetPendingMigrationsAsync();
                    if (pendingMigrationsSql != null)
                        await applicationSql.Database.MigrateAsync();
                    break;
                case "Npgsql":
                    var applicationPostgres = app.Services.CreateScope().ServiceProvider.GetRequiredService<DbContextPsSql>();
                    var pendingMigrationsPostgres = await applicationPostgres.Database.GetPendingMigrationsAsync();
                    if (pendingMigrationsPostgres != null)
                        await applicationPostgres.Database.MigrateAsync();
                    break;
                case "MySql":
                    var applicationMySql = app.Services.CreateScope().ServiceProvider.GetRequiredService<DbContextMySql>();
                    var pendingMigrationsMySql = await applicationMySql.Database.GetPendingMigrationsAsync();
                    if (pendingMigrationsMySql != null)
                        await applicationMySql.Database.MigrateAsync();
                    break;
                default: throw new Exception("Engine no soportado para migraciones");
            }
        }
    }
}
