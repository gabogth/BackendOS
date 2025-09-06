using nest.core.dominio.Security;
using nest.core.infraestructura.db.DbContext.Provider;
using nest.core.infraestructura.db.DbContext;
using nest.core.aplication.auth;

namespace nest.core.security.Extensions
{
    public static class MigrationResolver
    {
        public static void PickProvider(WebApplicationBuilder builder) 
        {
            string connection = MigrationService.MigrationConnection();
            string engine = MigrationService.GetEngine(builder.Configuration, connection);
            Console.WriteLine($"Resolviendo proveedor de base de datos para migraciones: {engine}");
            Console.WriteLine($"Conexion actual: {connection}");
            switch (engine)
            {
                case "SqlServer":
                    builder.Services.AddDbContext<NestDbContext, DbContextSqlServer>();
                    builder.Services
                        .AddIdentity<ApplicationUser, ApplicationRole>()
                        .AddEntityFrameworkStores<DbContextSqlServer>();
                    break;
                case "Npgsql":
                    builder.Services.AddDbContext<NestDbContext, DbContextPsSql>();
                    builder.Services
                        .AddIdentity<ApplicationUser, ApplicationRole>()
                        .AddEntityFrameworkStores<DbContextPsSql>();
                    break;
                case "MySql":
                    builder.Services.AddDbContext<NestDbContext, DbContextMySql>();
                    builder.Services
                        .AddIdentity<ApplicationUser, ApplicationRole>()
                        .AddEntityFrameworkStores<DbContextMySql>();
                    break;
                default: throw new Exception("Engine no soportado para migraciones");
            }
        }
    }
}
