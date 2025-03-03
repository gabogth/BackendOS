using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.RRHH
{
    internal class SexoEntityConfig : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<Sexo> ObtenerInformacionInicial()
        {
            List<Sexo> roles = new List<Sexo>()
            {
                new Sexo { Id = 1, Nombre = "Hombre" },
                new Sexo { Id = 2, Nombre = "Mujer" },
                new Sexo { Id = 3, Nombre = "Otros" }
            };
            return roles;
        }
    }
}
