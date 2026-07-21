using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class PersonalCargoExternoEntityConfig : IEntityTypeConfiguration<PersonalCargoExterno>
    {
        public void Configure(EntityTypeBuilder<PersonalCargoExterno> builder)
        {
            builder.ToTable("personal_cargo_externo", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.HasIndex(x => new { x.PersonalId, x.CargoId }).IsUnique();
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.Personal)
                .WithMany()
                .HasForeignKey(x => x.PersonalId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Cargo)
                .WithMany()
                .HasForeignKey(x => x.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
