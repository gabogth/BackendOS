using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General;

namespace nest.core.infraestructura.db.General
{
    internal class DepartamentoEntityConfig : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("departamento", "dbo");
            builder.HasMany(d => d.Provincias)
                .WithOne(p => p.Departamento)
                .HasForeignKey(p => p.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(GetData());
        }

        private List<Departamento> GetData()
        {
            return new List<Departamento>
            {
                new Departamento { Id = 1, Nombre = "Amazonas", PaisId = 1 },
                new Departamento { Id = 2, Nombre = "Áncash", PaisId = 1 },
                new Departamento { Id = 3, Nombre = "Apurímac", PaisId = 1 },
                new Departamento { Id = 4, Nombre = "Arequipa", PaisId = 1 },
                new Departamento { Id = 5, Nombre = "Ayacucho", PaisId = 1 },
                new Departamento { Id = 6, Nombre = "Cajamarca", PaisId = 1 },
                new Departamento { Id = 7, Nombre = "Callao", PaisId = 1 },
                new Departamento { Id = 8, Nombre = "Cusco", PaisId = 1 },
                new Departamento { Id = 9, Nombre = "Huancavelica", PaisId = 1 },
                new Departamento { Id = 10, Nombre = "Huánuco", PaisId = 1 },
                new Departamento { Id = 11, Nombre = "Ica", PaisId = 1 },
                new Departamento { Id = 12, Nombre = "Junín", PaisId = 1 },
                new Departamento { Id = 13, Nombre = "La Libertad", PaisId = 1 },
                new Departamento { Id = 14, Nombre = "Lambayeque", PaisId = 1 },
                new Departamento { Id = 15, Nombre = "Lima", PaisId = 1 },
                new Departamento { Id = 16, Nombre = "Loreto", PaisId = 1 },
                new Departamento { Id = 17, Nombre = "Madre de Dios", PaisId = 1 },
                new Departamento { Id = 18, Nombre = "Moquegua", PaisId = 1 },
                new Departamento { Id = 19, Nombre = "Pasco", PaisId = 1 },
                new Departamento { Id = 20, Nombre = "Piura", PaisId = 1 },
                new Departamento { Id = 21, Nombre = "Puno", PaisId = 1 },
                new Departamento { Id = 22, Nombre = "San Martín", PaisId = 1 },
                new Departamento { Id = 23, Nombre = "Tacna", PaisId = 1 },
                new Departamento { Id = 24, Nombre = "Tumbes", PaisId = 1 },
                new Departamento { Id = 25, Nombre = "Ucayali", PaisId = 1 }
            };
        }

    }
}
