using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.infraestructura.db.Contabilidad
{
    public class CuentaContableEntityConfig : IEntityTypeConfiguration<CuentaContable>
    {
        public void Configure(EntityTypeBuilder<CuentaContable> builder)
        {
            builder.ToTable("cuenta_contable", "contabilidad");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.ES)
                .HasMaxLength(1);
            builder.HasOne(x => x.CuentaContableTipo)
                .WithMany()
                .HasForeignKey(x => x.CuentaContableTipoId);
            builder.HasOne(x => x.Padre)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.PadreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
