using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    internal class FinancieroDetalleEntityConfig : IEntityTypeConfiguration<FinancieroDetalle>
    {
        public void Configure(EntityTypeBuilder<FinancieroDetalle> builder)
        {
            builder.ToTable("financiero_detalle", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.Property(x => x.SerieDocumento)
                .HasMaxLength(4);
            builder.Property(x => x.NumeroDocumento)
                .HasMaxLength(11);
            builder.Property(x => x.Concepto)
                .HasMaxLength(80);
            builder.HasOne(d => d.FinancieroCabecera)
               .WithMany(c => c.FinancieroDetalles)
               .HasForeignKey(d => d.FinancieroCabeceraId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Tercero)
                .WithMany()
                .HasForeignKey(x => x.TerceroId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.DocumentoTipo)
                .WithMany()
                .HasForeignKey(x => x.DocumentoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CuentaCorriente)
                .WithMany()
                .HasForeignKey(x => x.CuentaCorrienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
