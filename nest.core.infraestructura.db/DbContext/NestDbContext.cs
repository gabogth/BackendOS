using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Tenant;
using System.Reflection;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly string connectionString;
        private readonly string usuario;
        private readonly string engine;
        public NestDbContext(DbContextOptions<NestDbContext> options, IConnectionStringService connectionStringService)
        : base(options)
        {
            connectionStringService.Build();
            this.connectionString = connectionStringService.ConnectionTenant;
            this.usuario = connectionStringService.Usuario;
            this.engine = connectionStringService.Engine;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
            switch (this.engine) {
                case "SQLSERVER":
                    optionsBuilder.UseSqlServer(this.connectionString, b => {
                        b.MigrationsAssembly("nest.core.security");
                    });
                    break;
                case "POSTGRES":
                    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                    optionsBuilder.UseNpgsql(this.connectionString, b => {
                        b.MigrationsAssembly("nest.core.security");
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
