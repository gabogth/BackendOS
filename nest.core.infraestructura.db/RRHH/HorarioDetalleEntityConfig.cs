using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioDetalleEntityConfig : IEntityTypeConfiguration<HorarioDetalle>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "horario_detalle";
        public void Configure(EntityTypeBuilder<HorarioDetalle> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
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
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, HorarioDetalleEntityConfig.SCHEMA, HorarioDetalleEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, HorarioDetalleEntityConfig.SCHEMA, HorarioDetalleEntityConfig.TABLE, cancellationToken);
    }
}
