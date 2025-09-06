using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.ProvinciaEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.db.General
{
    public class ProvinciaEntityConfig : IEntityTypeConfiguration<Provincia>
    {
        public static readonly string SCHEMA = "dbo";
        public static readonly string TABLE = "provincia";
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<ProvinciaValueGenerator>();
            builder.HasMany(p => p.Distritos)
                .WithOne(d => d.Provincia)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(GetData());
        }

        private List<Provincia> GetData()
        {
            return new List<Provincia>
            {
                new Provincia { Id = 1, Nombre = "Arequipa", DepartamentoId = 4 },
                new Provincia { Id = 2, Nombre = "Camaná", DepartamentoId = 4 },
                new Provincia { Id = 3, Nombre = "Caravelí", DepartamentoId = 4 },
                new Provincia { Id = 4, Nombre = "Castilla", DepartamentoId = 4 },
                new Provincia { Id = 5, Nombre = "Caylloma", DepartamentoId = 4 },
                new Provincia { Id = 6, Nombre = "Condesuyos", DepartamentoId = 4 },
                new Provincia { Id = 7, Nombre = "Islay", DepartamentoId = 4 },
                new Provincia { Id = 8, Nombre = "La Unión", DepartamentoId = 4 }
            };
        }
    }
    public class ProvinciaValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<int>(entry, object () => ((NestDbContext)entry.Context).Provincia.Max(x => x.Id));
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<int>(entry, object () => ((NestDbContext)entry.Context).Provincia.Max(x => x.Id), cancellationToken);
    }
}
