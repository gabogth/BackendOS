using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenServicioCabeceraEntityConfig : IEntityTypeConfiguration<OrdenServicioCabecera>
    {
        public void Configure(EntityTypeBuilder<OrdenServicioCabecera> builder)
        {
            builder.ToTable("orden_servicio_cabecera", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.OrdenServicioTipo)
                .WithMany()
                .HasForeignKey(x => x.OrdenServicioTipoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
