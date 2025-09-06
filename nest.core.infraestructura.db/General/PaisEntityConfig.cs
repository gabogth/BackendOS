using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.PaisEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.db.General
{
    public class PaisEntityConfig : IEntityTypeConfiguration<Pais>
    {
        public static readonly string SCHEMA = "dbo";
        public static readonly string TABLE = "pais";
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<PaisValueGenerator>();
            builder.HasMany(p => p.Departamentos)
                .WithOne(d => d.Pais)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(GetData());
        }

        private List<Pais> GetData()
        {
            return new List<Pais>
            {
                new Pais { Id = 1, Nombre = "Perú", CodigoIso = "PE", CodigoTelefono = "+51" },
                new Pais { Id = 2, Nombre = "Estados Unidos", CodigoIso = "US", CodigoTelefono = "+1" },
                new Pais { Id = 3, Nombre = "México", CodigoIso = "MX", CodigoTelefono = "+52" },
                new Pais { Id = 4, Nombre = "Argentina", CodigoIso = "AR", CodigoTelefono = "+54" },
                new Pais { Id = 5, Nombre = "Chile", CodigoIso = "CL", CodigoTelefono = "+56" },
                new Pais { Id = 6, Nombre = "Colombia", CodigoIso = "CO", CodigoTelefono = "+57" },
                new Pais { Id = 7, Nombre = "España", CodigoIso = "ES", CodigoTelefono = "+34" },
                new Pais { Id = 8, Nombre = "Brasil", CodigoIso = "BR", CodigoTelefono = "+55" },
                new Pais { Id = 9, Nombre = "Ecuador", CodigoIso = "EC", CodigoTelefono = "+593" },
                new Pais { Id = 10, Nombre = "Canadá", CodigoIso = "CA", CodigoTelefono = "+1" },
                new Pais { Id = 11, Nombre = "Francia", CodigoIso = "FR", CodigoTelefono = "+33" },
                new Pais { Id = 12, Nombre = "Reino Unido", CodigoIso = "GB", CodigoTelefono = "+44" },
                new Pais { Id = 13, Nombre = "Italia", CodigoIso = "IT", CodigoTelefono = "+39" },
                new Pais { Id = 14, Nombre = "Alemania", CodigoIso = "DE", CodigoTelefono = "+49" },
                new Pais { Id = 15, Nombre = "Japón", CodigoIso = "JP", CodigoTelefono = "+81" },
                new Pais { Id = 16, Nombre = "China", CodigoIso = "CN", CodigoTelefono = "+86" },
                new Pais { Id = 17, Nombre = "India", CodigoIso = "IN", CodigoTelefono = "+91" },
                new Pais { Id = 18, Nombre = "Australia", CodigoIso = "AU", CodigoTelefono = "+61" },
                new Pais { Id = 19, Nombre = "Sudáfrica", CodigoIso = "ZA", CodigoTelefono = "+27" },
                new Pais { Id = 20, Nombre = "Nueva Zelanda", CodigoIso = "NZ", CodigoTelefono = "+64" }
            };
        }

    }
    public class PaisValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<int>(entry, object () => ((NestDbContext)entry.Context).Pais.Max(x => x.Id));
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<int>(entry, object () => ((NestDbContext)entry.Context).Pais.Max(x => x.Id), cancellationToken);
    }
}
