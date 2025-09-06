using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.infraestructura.db.Patrimonial
{
    public class UbicacionTecnicaEntityConfig : IEntityTypeConfiguration<UbicacionTecnica>
    {
        public void Configure(EntityTypeBuilder<UbicacionTecnica> builder)
        {
            builder.ToTable("ubicacion_tecnica", "patrimonial");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.Tercero)
                .WithMany()
                .HasForeignKey(x => x.TerceroId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Padre)
               .WithMany(x => x.Children)
               .HasForeignKey(x => x.PadreId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
