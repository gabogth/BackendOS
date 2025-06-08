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
                           .Where(t => typeof(IAuditable).IsAssignableFrom(t.ClrType))
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

                audit.Property(typeof(DateTime), "FechaAuditoria");
                audit.Property(typeof(string), "AccionAuditoria").HasMaxLength(10);
                audit.Property(typeof(string), "UsuarioAuditoria").HasMaxLength(200);
                audit.Property(typeof(string), "App").HasMaxLength(100);
                audit.Property(typeof(string), "AppVersion").HasMaxLength(20);
                audit.Property(typeof(string), "AssemblyName").HasMaxLength(60);
                audit.ToTable(tableName, schemaName);
            }
        }
    }
}
