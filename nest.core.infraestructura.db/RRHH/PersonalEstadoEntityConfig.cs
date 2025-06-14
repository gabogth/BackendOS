using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.db.RRHH
{
    public class PersonalEstadoEntityConfig : IEntityTypeConfiguration<PersonalEstado>
    {
        public void Configure(EntityTypeBuilder<PersonalEstado> builder)
        {
            builder.ToTable("personal_estado", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<CargoValueGenerator>();
            builder.HasData(ObtenerInformacionInicial());
        }
        public List<PersonalEstado> ObtenerInformacionInicial()
        {
            List<PersonalEstado> roles = new List<PersonalEstado>()
            {
                new PersonalEstado { Id = 1, Nombre = "ACTIVO" },
                new PersonalEstado { Id = 2, Nombre = "RENUNCIA" },
                new PersonalEstado { Id = 3, Nombre = "DESPEDIDO" },
                new PersonalEstado { Id = 4, Nombre = "ABANDONO" },
                new PersonalEstado { Id = 5, Nombre = "SUSPENDIDO" },
            };
            return roles;
        }
        public class PersonalEstadoValueGenerator : ValueGenerator<byte>
        {
            public override bool GeneratesTemporaryValues => false;
            public override byte Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<byte>(entry, object () => ((NestDbContext)entry.Context).PersonalEstado.Max(x => x.Id));
            public override async ValueTask<byte> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<byte>(entry, object () => ((NestDbContext)entry.Context).PersonalEstado.Max(x => x.Id), cancellationToken);
        }
    }
}
