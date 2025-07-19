using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.infraestructura.db.Contabilidad
{
    public class CuentaContableTipoEntityConfig : IEntityTypeConfiguration<CuentaContableTipo>
    {
        public void Configure(EntityTypeBuilder<CuentaContableTipo> builder)
        {
            builder.ToTable("cuenta_contable_tipo", "contabilidad");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
