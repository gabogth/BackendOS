using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class FinancieroCabeceraEntityConfig : IEntityTypeConfiguration<FinancieroCabecera>
    {
        public void Configure(EntityTypeBuilder<FinancieroCabecera> builder)
        {
            builder.ToTable("financiero_cabecera", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.Property(x => x.Comentarios)
                .HasMaxLength(-1);
            builder.Property(x => x.SerieDocumentoGen)
                .HasMaxLength(4);
            builder.Property(x => x.NumeroDocumentoGen)
                .HasMaxLength(11);
            builder.HasOne(x => x.PuntoFinanciero)
                .WithMany()
                .HasForeignKey(x => x.PuntoFinancieroId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.OrigenFinanciero)
                .WithMany()
                .HasForeignKey(x => x.OrigenFinancieroId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.TerceroGen)
                .WithMany()
                .HasForeignKey(x => x.TerceroGenId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.DocumentoTipoGen)
                .WithMany()
                .HasForeignKey(x => x.DocumentoTipoGenId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
