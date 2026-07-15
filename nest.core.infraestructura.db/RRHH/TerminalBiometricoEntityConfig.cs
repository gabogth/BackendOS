using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class TerminalBiometricoEntityConfig : IEntityTypeConfiguration<TerminalBiometrico>
    {
        public void Configure(EntityTypeBuilder<TerminalBiometrico> builder)
        {
            builder.ToTable("terminal_biometrico", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
        }
    }
}
