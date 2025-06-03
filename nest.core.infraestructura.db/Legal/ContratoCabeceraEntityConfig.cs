using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.Legal
{
    public class ContratoCabeceraEntityConfig : IEntityTypeConfiguration<ContratoCabecera>
    {
        public void Configure(EntityTypeBuilder<ContratoCabecera> builder)
        {
            builder.ToTable("contrato_cabecera", "legal");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<ContratoCabeceraValueGenerator>();
            builder.Property(x => x.Resumen)
                .HasMaxLength(-1);
            builder.Property(x => x.Descripcion)
                .HasMaxLength(-1);
            builder.HasIndex(x => new { x.ContratoTipoId, x.Numero }).IsUnique();
            builder.HasOne(x => x.ContratoTipo)
                .WithMany()
                .HasForeignKey(x => x.ContratoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class ContratoCabeceraValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<ContratoCabecera>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<ContratoCabecera>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}