using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Legal.ContratoDetalleEntities;
using nest.core.dominio.Legal.ContratoPersonalEntities;

namespace nest.core.infraestructura.db.Legal
{
    public class ContratoCabeceraEntityConfig : IEntityTypeConfiguration<ContratoCabecera>
    {
        public static readonly string SCHEMA = "legal";
        public static readonly string TABLE = "contrato_cabecera";
        public void Configure(EntityTypeBuilder<ContratoCabecera> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.Resumen)
                .HasMaxLength(-1);
            builder.Property(x => x.Descripcion)
                .HasMaxLength(-1);
            builder.HasIndex(x => new { x.ContratoTipoId, x.Numero }).IsUnique();
            builder.HasOne(x => x.ContratoTipo)
                .WithMany()
                .HasForeignKey(x => x.ContratoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ContratoPersonal)
                .WithOne(p => p.ContratoCabecera)
                .HasForeignKey<ContratoPersonal>(p => p.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Detalles)
                .WithOne(d => d.ContratoCabecera)
                .HasForeignKey(d => d.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}