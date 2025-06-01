using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.Legal
{
    public class ContratoDetalleEntityConfig : IEntityTypeConfiguration<ContratoDetalle>
    {
        public void Configure(EntityTypeBuilder<ContratoDetalle> builder)
        {
            builder.ToTable("contrato_detalle", "legal");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ContratoCabecera)
                .WithMany()
                .HasForeignKey(x => x.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Persona)
                .WithMany()
                .HasForeignKey(x => x.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
