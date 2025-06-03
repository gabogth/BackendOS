using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Audit;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Audit
{
    public class AuditLogEntityConfig : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasValueGenerator<AuditLogValueGenerator>();
            builder.ToTable("audit_log", "audit");
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
        public override long Next(EntityEntry entry) =>
            (entry.Context.Set<AuditLog>().Max(g => (long?)g.Id) ?? 0) + 1;
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<AuditLog>().MaxAsync(g => (long?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
