using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class TerceroEntityConfig : IEntityTypeConfiguration<Tercero>
    {
        public void Configure(EntityTypeBuilder<Tercero> builder)
        {
            builder.ToTable("tercero", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.HasOne(x => x.DocumentoIdentidadTipoFinanciero)
                .WithMany()
                .HasForeignKey(x => x.DocumentoIdentidadTipoFinancieroId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CuentaContablePorCobrar)
                .WithMany()
                .HasForeignKey(x => x.CuentaContablePorCobrarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CuentaContablePorPagar)
                .WithMany()
                .HasForeignKey(x => x.CuentaContablePorPagarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Persona)
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
