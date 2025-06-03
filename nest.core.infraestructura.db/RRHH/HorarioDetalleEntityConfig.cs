using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioDetalleEntityConfig : IEntityTypeConfiguration<HorarioDetalle>
    {
        public void Configure(EntityTypeBuilder<HorarioDetalle> builder)
        {
            builder.ToTable("horario_detalle", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<HorarioDetalleValueGenerator>();
            builder.HasOne(x => x.HorarioCabecera)
                .WithMany(x => x.HorarioDetalles)
                .HasForeignKey(x => x.HorarioCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.GrupoHorario)
                .WithMany()
                .HasForeignKey(x => x.GrupoHorarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class HorarioDetalleValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<HorarioDetalle>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<HorarioDetalle>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
