using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Audit;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Audit
{
    public class AuditLogEntityConfig : IEntityTypeConfiguration<AuditLog>
    {
        public static readonly string SCHEMA = "audit";
        public static readonly string TABLE = "audit_log";
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasValueGenerator<AuditLogValueGenerator>();
            builder.ToTable(TABLE, SCHEMA);
            builder.Property(x => x.NewValues)
                .HasMaxLength(-1);
            builder.Property(x => x.OldValues)
                .HasMaxLength(-1);
            builder.Property(x => x.EntidadNombre)
                .HasMaxLength(-1);
        }
    }
    public class AuditLogValueGenerator : ValueGenerator<long>
    {
        public override bool GeneratesTemporaryValues => false;
        public override long Next(EntityEntry entry) => GeneradorCorrelativo.GetValue(entry.Context, AuditLogEntityConfig.SCHEMA, AuditLogEntityConfig.TABLE);
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync(entry.Context, AuditLogEntityConfig.Schema, AuditLogEntityConfig.Table, cancellationToken);
    }
}
