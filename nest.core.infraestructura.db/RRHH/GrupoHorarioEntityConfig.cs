using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoHorarioEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.RRHH
{
    public class GrupoHorarioEntityConfig : IEntityTypeConfiguration<GrupoHorario>
    {
        public void Configure(EntityTypeBuilder<GrupoHorario> builder)
        {
            builder.ToTable("grupo_horario", "rrhh");
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
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<GrupoHorario>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<GrupoHorario>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
