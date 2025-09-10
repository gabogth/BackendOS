using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Tenant;
using nest.core.infraestructura.db.DbContext.Convention;
using System.Reflection;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        protected readonly string usuario;
        protected readonly RequestParameters requestParameters;
        protected readonly IConnectionStringService connectionStringService;
        public NestDbContext(DbContextOptions options, IConnectionStringService connectionStringService)
        : base(options)
        {
            usuario = connectionStringService.Usuario;
            requestParameters = connectionStringService.Request;
            this.connectionStringService = connectionStringService;
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
