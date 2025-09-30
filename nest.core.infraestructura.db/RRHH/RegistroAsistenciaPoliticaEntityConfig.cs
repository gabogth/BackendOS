using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.db.RRHH
{
    public class RegistroAsistenciaPoliticaEntityConfig : IEntityTypeConfiguration<RegistroAsistenciaPolitica>
    {
        public void Configure(EntityTypeBuilder<RegistroAsistenciaPolitica> builder)
        {
            builder.ToTable("registro_asistencia_politica", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<CargoValueGenerator>();
        }
    }
    public class RegistroAsistenciaPoliticaValueGenerator : ValueGenerator<long>
    {
        public override bool GeneratesTemporaryValues => false;
        public override long Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<long>(entry, object () => ((NestDbContext)entry.Context).Cargos.Max(x => x.Id));
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<long>(entry, object () => ((NestDbContext)entry.Context).Cargos.Max(x => x.Id), cancellationToken);
    }
}
