using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.SexoEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.infraestructura.db.DbContext;

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
            List<Sexo> entidades = new List<Sexo>()
            {
                new Sexo { Id = 1, Nombre = "Masculino", NombreCorto = "M" },
                new Sexo { Id = 2, Nombre = "Femenino", NombreCorto = "F" },
            };
            return entidades;
        }
    }

    public class SexoValueGenerator : ValueGenerator<byte>
    {
        public override bool GeneratesTemporaryValues => false;
        public override byte Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<byte>(entry, object () => (int)((NestDbContext)entry.Context).Sexos.Max(x => x.Id));
        public override async ValueTask<byte> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<byte>(entry, object () => (int)((NestDbContext)entry.Context).Sexos.Max(x => x.Id), cancellationToken);
    }
}
