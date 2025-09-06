using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.infraestructura.db.Patrimonial
{
    public class ActivoEntityConfig : IEntityTypeConfiguration<Activo>
    {
        public void Configure(EntityTypeBuilder<Activo> builder)
        {
            builder.ToTable("activo", "patrimonial");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.ProductoLote)
                .WithMany()
                .HasForeignKey(x => x.ProductoLoteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CentroDeCostos)
                .WithMany()
                .HasForeignKey(x => x.CentroDeCostosId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Tercero)
                .WithMany()
                .HasForeignKey(x => x.TerceroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
