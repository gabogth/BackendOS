using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.FinancieroLogisticaEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class FinancieroLogisticaEntityConfig : IEntityTypeConfiguration<FinancieroLogistica>
    {
        public void Configure(EntityTypeBuilder<FinancieroLogistica> builder)
        {
            builder.ToTable("financiero_logistica", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasIndex(x => new { x.FinancieroDetalleId, x.InventarioCabeceraId });
            builder.HasOne(x => x.FinancieroDetalle)
                .WithMany()
                .HasForeignKey(x => x.FinancieroDetalleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.InventarioCabecera)
                .WithMany()
                .HasForeignKey(x => x.InventarioCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
