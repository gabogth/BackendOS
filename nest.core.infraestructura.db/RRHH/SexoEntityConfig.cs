using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.RRHH
{
    internal class SexoEntityConfig : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable("sexo", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<Sexo> ObtenerInformacionInicial()
        {
            List<Sexo> roles = new List<Sexo>()
            {
                new Sexo { Id = 1, Nombre = "Hombre", NombreCorto = "H" },
                new Sexo { Id = 2, Nombre = "Mujer", NombreCorto = "M" },
                new Sexo { Id = 3, Nombre = "Otros", NombreCorto = "O" }
            };
            return roles;
        }
    }
}
