using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using nest.core.dominio.Security.Audit;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace nest.core.infraestructura.db.DbContext.Convention
{
    public class AuditConvention : IModelFinalizingConvention
    {
        public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> _)
        {
            var auditable = modelBuilder.Metadata.GetEntityTypes()
                           .Where(t => typeof(IAuditable).IsAssignableFrom(t.ClrType) || t.GetTableName().ToLower().StartsWith("aspnet"))
                           .ToList();
            foreach (var entity in auditable)
            {
                var auditName = $"{entity.ClrType.Name}Audit";
                var tableName = $"{entity.GetTableName()}_audit";
                var schemaName = entity.GetSchema() ?? "dbo";

                var audit = modelBuilder.SharedTypeEntity(auditName, typeof(Dictionary<string, object>));
                

                var auditId = audit.Property(typeof(long), "AuditId")
                    .IsRequired(true)
                    .HasValueGenerationStrategy(MySqlValueGenerationStrategy.None)
                    .HasValueGenerationStrategy(SqlServerValueGenerationStrategy.None)
                    .HasValueGenerationStrategy(NpgsqlValueGenerationStrategy.None)
                    .HasValueGenerator(typeof(GenericValueGenerator<long>));
                audit.PrimaryKey(new List<IConventionProperty> { auditId.Metadata });

                foreach (var p in entity.GetProperties())
                    audit.Property(p.ClrType, p.Name);

                audit.Property(typeof(DateTime), "AuditFecha");
                audit.Property(typeof(string), "AuditAccion").HasMaxLength(10);
                audit.Property(typeof(string), "AuditUsuario").HasMaxLength(200);
                audit.Property(typeof(string), "AuditApp").HasMaxLength(100);
                audit.Property(typeof(string), "AuditAppVersion").HasMaxLength(20);
                audit.Property(typeof(string), "AuditAssemblyName").HasMaxLength(100);
                audit.Property(typeof(string), "AuditRequestId").HasMaxLength(100);
                audit.Property(typeof(string), "AuditPath").HasMaxLength(-1);
                audit.Property(typeof(string), "AuditMethod").HasMaxLength(20);
                audit.Property(typeof(string), "AuditIpRemoteOrigin").HasMaxLength(40);
                audit.Property(typeof(string), "AuditUserAgent").HasMaxLength(400);
                audit.Property(typeof(string), "AuditCurrentCulture").HasMaxLength(20);
                audit.Property(typeof(string), "AuditContentType").HasMaxLength(40);
                audit.Property(typeof(bool), "AuditIsHttps");
                audit.Property(typeof(string), "AuditHost").HasMaxLength(200);
                audit.Property(typeof(string), "AuditProtocol").HasMaxLength(40);
                audit.Property(typeof(string), "AuditQueryString").HasMaxLength(1000);
                audit.Property(typeof(string), "AuditAcceptLanguage").HasMaxLength(40);
                audit.Property(typeof(string), "AuditOrigin").HasMaxLength(400);
                audit.Property(typeof(string), "AuditReferer").HasMaxLength(1000);
                audit.Property(typeof(string), "AuditPlatform").HasMaxLength(100);
                audit.Property(typeof(string), "AuditUa").HasMaxLength(500);
                audit.ToTable(tableName, schemaName);
            }
        }
    }
}
