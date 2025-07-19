using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class EntidadFinancieraEntityConfig : IEntityTypeConfiguration<EntidadFinanciera>
    {
        public void Configure(EntityTypeBuilder<EntidadFinanciera> builder)
        {
            builder.ToTable("entidad_financiera", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
