using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.infraestructura.db.Costos
{
    public class CentroDeCostosEntityConfig : IEntityTypeConfiguration<CentroDeCostos>
    {
        public void Configure(EntityTypeBuilder<CentroDeCostos> builder)
        {
            builder.ToTable("centro_de_costos", "costos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.HasOne(x => x.Padre)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.PadreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
