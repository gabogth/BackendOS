using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Tenant;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Reflection;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        protected readonly string connectionString;
        protected readonly string usuario;
        protected readonly string engine;
        public NestDbContext(DbContextOptions options, IConnectionStringService connectionStringService)
        : base(options)
        {
            connectionStringService.Build();
            connectionString = connectionStringService.ConnectionTenant;
            usuario = connectionStringService.Usuario;
            engine = connectionStringService.Engine;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
            switch (engine)
            {
                case "SQLSERVER":
                    optionsBuilder.UseSqlServer(connectionString);
                    break;
                case "POSTGRES":
                    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                    optionsBuilder.UseNpgsql(connectionString);
                    break;
                case "MYSQL":
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), my =>
                    {
                        my.SchemaBehavior(
                            MySqlSchemaBehavior.Translate,
                            (schema, name) => $"{schema}_{name}"
                        );
                    });
                    break;
                default: throw new Exception("Engine no soportado");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var entityType in builder.Model.GetEntityTypes())
                if (entityType.GetTableName().StartsWith("AspNet"))
                    entityType.SetSchema("security");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(200);
            configurationBuilder.Properties<decimal>().HavePrecision(18, 4);
        }
    }
}
