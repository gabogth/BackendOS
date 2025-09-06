using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.FinancieroOrdenServicioEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class FinancieroOrdenServicioEntityConfig : IEntityTypeConfiguration<FinancieroOrdenServicio>
    {
        public void Configure(EntityTypeBuilder<FinancieroOrdenServicio> builder)
        {
            builder.ToTable("financiero_orden_servicio", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasIndex(x => new { x.FinancieroDetalleId, x.OrdenServicioCabeceraId });
            builder.HasOne(x => x.FinancieroDetalle)
                .WithMany()
                .HasForeignKey(x => x.FinancieroDetalleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.OrdenServicioCabecera)
                .WithMany()
                .HasForeignKey(x => x.OrdenServicioCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
