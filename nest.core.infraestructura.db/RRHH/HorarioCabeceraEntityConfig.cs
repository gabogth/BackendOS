using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioCabeceraEntityConfig : IEntityTypeConfiguration<HorarioCabecera>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "horario_cabecera";
        public void Configure(EntityTypeBuilder<HorarioCabecera> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<HorarioCabeceraValueGenerator>();
        }
    }
    public class HorarioCabeceraValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, HorarioCabeceraEntityConfig.SCHEMA, HorarioCabeceraEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, HorarioCabeceraEntityConfig.SCHEMA, HorarioCabeceraEntityConfig.TABLE, cancellationToken);
    }
}
