using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class TerceroEntityConfig : IEntityTypeConfiguration<Tercero>
    {
        public void Configure(EntityTypeBuilder<Tercero> builder)
        {
            builder.ToTable("tercero", "finanzas");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.HasOne(x => x.DocumentoIdentidadTipoFinanciero)
                .WithMany()
                .HasForeignKey(x => x.DocumentoIdentidadTipoFinancieroId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CuentaContablePorCobrar)
                .WithMany()
                .HasForeignKey(x => x.CuentaContablePorCobrarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CuentaContablePorPagar)
                .WithMany()
                .HasForeignKey(x => x.CuentaContablePorPagarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Persona)
                .WithOne(c => c.Tercero)
                .HasForeignKey<Tercero>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
