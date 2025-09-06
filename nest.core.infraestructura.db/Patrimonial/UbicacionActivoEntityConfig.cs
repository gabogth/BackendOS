using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.infraestructura.db.Patrimonial
{
    public class UbicacionActivoEntityConfig : IEntityTypeConfiguration<UbicacionActivo>
    {
        public void Configure(EntityTypeBuilder<UbicacionActivo> builder)
        {
            builder.ToTable("ubicacion_activo", "patrimonial");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.Activo)
                .WithMany()
                .HasForeignKey(x => x.ActivoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.UbicacionTecnica)
                .WithMany()
                .HasForeignKey(x => x.UbicacionTecnicaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ContratoCabecera)
                .WithMany()
                .HasForeignKey(x => x.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
