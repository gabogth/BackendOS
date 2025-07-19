using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class LaborEntityConfig : IEntityTypeConfiguration<Labor>
    {
        public void Configure(EntityTypeBuilder<Labor> builder)
        {
            builder.ToTable("labor", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
