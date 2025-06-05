using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
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
                .HasValueGenerator<ContratoDetalleValueGenerator>();
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
    public class ContratoDetalleValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, ContratoDetalleEntityConfig.SCHEMA, ContratoDetalleEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, ContratoDetalleEntityConfig.SCHEMA, ContratoDetalleEntityConfig.TABLE, cancellationToken);
    }
}
