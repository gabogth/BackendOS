using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using nest.core.dominio.Security;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.DbContext.Convention;
using nest.core.infraestructura.db.DbContext.Provider;

namespace nest.core.aplication.auth
{
    public static class DbContextSelector
    {
        public static void SelectProvider(WebApplicationBuilder builder, bool IsRun)
        {
            string connection = IsRun ? Environment.GetEnvironmentVariable("ENGINE") : MigrationService.MigrationConnection();
            Console.WriteLine($"Resolviendo proveedor de base de datos para migraciones: {connection}");
            Console.WriteLine($"Conexion actual: {connection}");
            switch (connection)
            {
                case "SqlServer":
                    builder.Services.AddDbContext<NestDbContext, DbContextSqlServer>((sp) => {
                        sp.AddInterceptors(new TenantGuardSaveChangesInterceptor());
                    });
                    builder.Services
                        .AddIdentity<ApplicationUser, ApplicationRole>()
                        .AddEntityFrameworkStores<DbContextSqlServer>();
                    break;
                case "Npgsql":
                    builder.Services.AddDbContext<NestDbContext, DbContextPsSql>((sp) => {
                        sp.AddInterceptors(new TenantGuardSaveChangesInterceptor());
                    });
                    builder.Services
                        .AddIdentity<ApplicationUser, ApplicationRole>()
                        .AddEntityFrameworkStores<DbContextPsSql>();
                    break;
                case "MySql":
                    builder.Services.AddDbContext<NestDbContext, DbContextMySql>((sp) => {
                        sp.AddInterceptors(new TenantGuardSaveChangesInterceptor());
                    });
                    builder.Services
                        .AddIdentity<ApplicationUser, ApplicationRole>()
                        .AddEntityFrameworkStores<DbContextMySql>();
                    break;
                default: throw new Exception("Engine no soportado para migraciones");
            }
        }
    }
}
