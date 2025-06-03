using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioCabeceraEntityConfig : IEntityTypeConfiguration<HorarioCabecera>
    {
        public void Configure(EntityTypeBuilder<HorarioCabecera> builder)
        {
            builder.ToTable("horario_cabecera", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<HorarioCabeceraValueGenerator>();
        }
    }
    public class HorarioCabeceraValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<HorarioCabecera>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<HorarioCabecera>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
