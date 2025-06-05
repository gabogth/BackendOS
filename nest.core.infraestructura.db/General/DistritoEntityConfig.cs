using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.infraestructura.db.General
{
    public class DistritoEntityConfig : IEntityTypeConfiguration<Distrito>
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            builder.ToTable("distrito", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.HasData(GetData());
        }

        private List<Distrito> GetData()
        {
            return new List<Distrito>
            {
                new Distrito { Id = 1, Nombre = "Arequipa", ProvinciaId = 1 },
                new Distrito { Id = 2, Nombre = "Alto Selva Alegre", ProvinciaId = 1 },
                new Distrito { Id = 3, Nombre = "Cayma", ProvinciaId = 1 },
                new Distrito { Id = 4, Nombre = "Characato", ProvinciaId = 1 },
                new Distrito { Id = 5, Nombre = "Chiguata", ProvinciaId = 1 },
                new Distrito { Id = 6, Nombre = "Jacobo Hunter", ProvinciaId = 1 },
                new Distrito { Id = 7, Nombre = "La Joya", ProvinciaId = 1 },
                new Distrito { Id = 8, Nombre = "Miraflores", ProvinciaId = 1 },
                new Distrito { Id = 9, Nombre = "Mollebaya", ProvinciaId = 1 },
                new Distrito { Id = 10, Nombre = "Sabandía", ProvinciaId = 1 },
                new Distrito { Id = 11, Nombre = "San Juan de Siguas", ProvinciaId = 1 },
                new Distrito { Id = 12, Nombre = "San Juan de Tarucani", ProvinciaId = 1 },
                new Distrito { Id = 13, Nombre = "Santa Isabel de Siguas", ProvinciaId = 1 },
                new Distrito { Id = 14, Nombre = "Santa Rita de Siguas", ProvinciaId = 1 },
                new Distrito { Id = 15, Nombre = "Sachaca", ProvinciaId = 1 },
                new Distrito { Id = 16, Nombre = "Simón Bolívar", ProvinciaId = 1 },
                new Distrito { Id = 17, Nombre = "Tiabaya", ProvinciaId = 1 },
                new Distrito { Id = 18, Nombre = "Yanahuara", ProvinciaId = 1 },
                new Distrito { Id = 19, Nombre = "Cerro Colorado", ProvinciaId = 1 },
                new Distrito { Id = 20, Nombre = "Quequeña", ProvinciaId = 1 },
                new Distrito { Id = 21, Nombre = "Yura", ProvinciaId = 1 },
                new Distrito { Id = 22, Nombre = "Socabaya", ProvinciaId = 1 },
                new Distrito { Id = 23, Nombre = "Polobaya", ProvinciaId = 1 },
                new Distrito { Id = 24, Nombre = "Vitor", ProvinciaId = 1 },
                new Distrito { Id = 25, Nombre = "La Unión", ProvinciaId = 1 },
                new Distrito { Id = 26, Nombre = "Santa Teresa", ProvinciaId = 1 },
                new Distrito { Id = 27, Nombre = "Aplao", ProvinciaId = 1 },
                new Distrito { Id = 28, Nombre = "Chivay", ProvinciaId = 1 },
                new Distrito { Id = 29, Nombre = "Ichuña", ProvinciaId = 1 },
                new Distrito { Id = 30, Nombre = "Macate", ProvinciaId = 1 },
                new Distrito { Id = 31, Nombre = "Huambo", ProvinciaId = 1 },
                new Distrito { Id = 32, Nombre = "Orcopampa", ProvinciaId = 1 },
                new Distrito { Id = 33, Nombre = "Chivay", ProvinciaId = 1 }
            };
        }
    }
}
