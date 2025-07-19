using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class PuntoFinancieroEntityConfig : IEntityTypeConfiguration<PuntoFinanciero>
    {
        public void Configure(EntityTypeBuilder<PuntoFinanciero> builder)
        {
            builder.ToTable("punto_financiero", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
