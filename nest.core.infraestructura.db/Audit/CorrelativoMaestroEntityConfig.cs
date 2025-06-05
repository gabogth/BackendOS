using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Audit;

namespace nest.core.infraestructura.db.Audit
{
    public class CorrelativoMaestroEntityConfig : IEntityTypeConfiguration<CorrelativoMaestro>
    {
        public static readonly string SCHEMA = "audit";
        public static readonly string TABLE = "correlativo_maestro";
        public void Configure(EntityTypeBuilder<CorrelativoMaestro> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => new { x.Schema, x.Table });
        }
    }
}
