using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenTrabajoPersonalEntityConfig : IEntityTypeConfiguration<OrdenTrabajoPersonal>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajoPersonal> builder)
        {
            builder.ToTable("orden_trabajo_personal", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.OrdenTrabajoCabecera)
                .WithMany()
                .HasForeignKey(x => x.OrdenTrabajoCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Persona)
                .WithMany()
                .HasForeignKey(x => x.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
