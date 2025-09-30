using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class RegistroAsistenciaPoliticaEntityConfig : IEntityTypeConfiguration<RegistroAsistenciaPolitica>
    {
        public void Configure(EntityTypeBuilder<RegistroAsistenciaPolitica> builder)
        {
            builder.ToTable("registro_asistencia_politica", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
