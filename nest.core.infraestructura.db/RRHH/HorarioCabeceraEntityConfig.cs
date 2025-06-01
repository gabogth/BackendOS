using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioCabeceraEntityConfig : IEntityTypeConfiguration<HorarioCabecera>
    {
        public void Configure(EntityTypeBuilder<HorarioCabecera> builder)
        {
            builder.ToTable("horario_cabecera", "rrhh");
            builder.HasKey(x => x.Id);
        }
    }
}
