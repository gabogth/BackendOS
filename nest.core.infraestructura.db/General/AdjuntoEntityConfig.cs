using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.General.AdjuntoEntities;

namespace nest.core.infraestructura.db.General
{
    public class AdjuntoEntityConfig : IEntityTypeConfiguration<Adjunto>
    {
        public void Configure(EntityTypeBuilder<Adjunto> builder)
        {
            builder.ToTable("adjunto", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
        }
    }
}
