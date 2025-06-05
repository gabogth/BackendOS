using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Audit;

namespace nest.core.infraestructura.db.Audit
{
    public class CorrelativoMaestroEntityConfig : IEntityTypeConfiguration<CorrelativoMaestro>
    {
        public void Configure(EntityTypeBuilder<CorrelativoMaestro> builder)
        {
            builder.ToTable("correlativo_maestro", "audit");
            builder.HasKey(x => new { x.Schema, x.Table });
        }
    }
}
