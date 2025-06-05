using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.SexoEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.General
{
    public class SexoEntityConfig : IEntityTypeConfiguration<Sexo>
    {
        public static readonly string SCHEMA = "dbo";
        public static readonly string TABLE = "sexo";
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<SexoValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<Sexo> ObtenerInformacionInicial()
        {
            List<Sexo> roles = new List<Sexo>()
            {
            };
            return roles;
        }
    }

    public class SexoValueGenerator : ValueGenerator<byte>
    {
        public override bool GeneratesTemporaryValues => false;
        public override byte Next(EntityEntry entry) => (byte)GeneradorCorrelativo.GetValue(entry.Context, SexoEntityConfig.SCHEMA, SexoEntityConfig.TABLE);
        public override async ValueTask<byte> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (byte)await GeneradorCorrelativo.GetValueAsync(entry.Context, SexoEntityConfig.SCHEMA, SexoEntityConfig.TABLE, cancellationToken);
    }
}
