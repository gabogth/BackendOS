using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class CuentaCorrienteEntityConfig : IEntityTypeConfiguration<CuentaCorriente>
    {
        public void Configure(EntityTypeBuilder<CuentaCorriente> builder)
        {
            builder.ToTable("cuenta_corriente", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.HasOne(x => x.EntidadFinanciera)
                .WithMany()
                .HasForeignKey(x => x.EntidadFinancieraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CuentaContable)
                .WithMany()
                .HasForeignKey(x => x.CuentaContableId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
