using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class OrigenFinancieroEntityConfig : IEntityTypeConfiguration<OrigenFinanciero>
    {
        public void Configure(EntityTypeBuilder<OrigenFinanciero> builder)
        {
            builder.ToTable("origen_financiero", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<short>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
