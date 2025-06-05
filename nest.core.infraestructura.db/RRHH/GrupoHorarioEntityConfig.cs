using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoHorarioEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.RRHH
{
    public class GrupoHorarioEntityConfig : IEntityTypeConfiguration<GrupoHorario>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "grupo_horario";
        public void Configure(EntityTypeBuilder<GrupoHorario> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GrupoHorarioValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }

    public class GrupoHorarioValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, GrupoHorarioEntityConfig.SCHEMA, GrupoHorarioEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, GrupoHorarioEntityConfig.SCHEMA, GrupoHorarioEntityConfig.TABLE, cancellationToken);
    }
}
