using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.Legal
{
    public class ContratoCabeceraEntityConfig : IEntityTypeConfiguration<ContratoCabecera>
    {
        public static readonly string SCHEMA = "legal";
        public static readonly string TABLE = "contrato_cabecera";
        public void Configure(EntityTypeBuilder<ContratoCabecera> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<ContratoCabeceraValueGenerator>();
            builder.Property(x => x.Resumen)
                .HasMaxLength(-1);
            builder.Property(x => x.Descripcion)
                .HasMaxLength(-1);
            builder.HasIndex(x => new { x.ContratoTipoId, x.Numero }).IsUnique();
            builder.HasOne(x => x.ContratoTipo)
                .WithMany()
                .HasForeignKey(x => x.ContratoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class ContratoCabeceraValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, ContratoCabeceraEntityConfig.SCHEMA, ContratoCabeceraEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, ContratoCabeceraEntityConfig.SCHEMA, ContratoCabeceraEntityConfig.TABLE, cancellationToken);
    }
}