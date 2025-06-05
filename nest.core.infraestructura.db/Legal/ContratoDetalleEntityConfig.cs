using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.Legal
{
    public class ContratoDetalleEntityConfig : IEntityTypeConfiguration<ContratoDetalle>
    {
        public static readonly string SCHEMA = "legal";
        public static readonly string TABLE = "contrato_detalle";
        public void Configure(EntityTypeBuilder<ContratoDetalle> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
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
