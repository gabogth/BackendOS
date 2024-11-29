using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.RRHH
{
    public class LicenciaConducirEntityConfig : IEntityTypeConfiguration<LicenciaConducir>
    {
        public void Configure(EntityTypeBuilder<LicenciaConducir> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<LicenciaConducir> ObtenerInformacionInicial()
        {
            List<LicenciaConducir> roles = new List<LicenciaConducir>()
            {
                new LicenciaConducir { Id = 1, Nombre = "AIA", Nivel = 1 },
                new LicenciaConducir { Id = 2, Nombre = "AIIA", Nivel = 2 },
                new LicenciaConducir { Id = 3, Nombre = "AIIB", Nivel = 3 },
                new LicenciaConducir { Id = 4, Nombre = "AIIIA", Nivel = 4 },
                new LicenciaConducir { Id = 5, Nombre = "AIIIB", Nivel = 5 },
                new LicenciaConducir { Id = 6, Nombre = "AIIIC", Nivel = 6 },
                new LicenciaConducir { Id = 7, Nombre = "B1", Nivel = 7 },
                new LicenciaConducir { Id = 7, Nombre = "BIIA", Nivel = 7 },
                new LicenciaConducir { Id = 7, Nombre = "BIIB", Nivel = 7 }
            };
            return roles;
        }
    }
}
