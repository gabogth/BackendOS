using nest.core.dominio.Security;
using nest.core.infraestructura.db.DbContext.Provider;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.security.Extensions
{
    public static class MigrationServices
    {
        public static bool IsMigration() 
        {
            var commandMigration = Environment.GetCommandLineArgs().FirstOrDefault(x => x == "migrations" || x == "database");
            return !string.IsNullOrWhiteSpace(commandMigration);
        }

        private static string GetEngine(WebApplicationBuilder builder)
        {
            var selected = builder.Configuration.GetSection("Migrations").GetValue<string>("SelectedDb");
            return builder.Configuration.GetValue<string>($"Connections:{selected}:Engine");
        }

        public static void PickProvider(WebApplicationBuilder builder) 
        {
            string engine = GetEngine(builder);
            if (engine == "SQLSERVER")
            {
                Console.WriteLine("Migration SQLSERVER");
                builder.Services.AddDbContext<NestDbContext, DbContextSqlServer>();
                builder.Services
                    .AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<DbContextSqlServer>();
            }
            if (engine == "POSTGRES")
            {
                Console.WriteLine("Migration POSTGRES");
                builder.Services.AddDbContext<NestDbContext, DbContextPsSql>();
                builder.Services
                    .AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<DbContextPsSql>();
            }
            if (engine == "MYSQL")
            {
                Console.WriteLine("Migration MYSQL");
                builder.Services.AddDbContext<NestDbContext, DbContextMySql>();
                builder.Services
                    .AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<DbContextMySql>();
            }
        }
    }
}
