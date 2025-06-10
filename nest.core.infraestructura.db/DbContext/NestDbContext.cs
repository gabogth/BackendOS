using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.db.DbContext.Convention;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Reflection;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        protected readonly string connectionString;
        protected readonly string usuario;
        protected readonly string engine;
        protected readonly RequestParameters requestParameters;
        public NestDbContext(DbContextOptions options, IConnectionStringService connectionStringService)
        : base(options)
        {
            connectionStringService.Build();
            connectionString = connectionStringService.ConnectionTenant;
            usuario = connectionStringService.Usuario;
            engine = connectionStringService.Engine;
            requestParameters = connectionStringService.Request;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
            switch (engine)
            {
                case "SqlServer":
                    optionsBuilder.UseSqlServer(connectionString);
                    break;
                case "Npgsql":
                    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                    optionsBuilder.UseNpgsql(connectionString);
                    break;
                case "MySql":
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
            configurationBuilder.Conventions.Add(_ => new AuditConvention());
        }
    }
}
