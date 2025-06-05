using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Audit;

namespace nest.core.infraestructura.db.Audit
{
    public class AuditLogEntityConfig : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("audit_log", "audit");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasValueGenerator<GenericValueGenerator<long>>();
            builder.Property(x => x.NewValues)
                .HasMaxLength(-1);
            builder.Property(x => x.OldValues)
                .HasMaxLength(-1);
            builder.Property(x => x.EntidadNombre)
                .HasMaxLength(-1);
        }
    }
}
