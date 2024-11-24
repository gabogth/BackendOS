using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica.Transaccional;

namespace nest.core.infraestructura.db.Logistica.Transaccional
{
    public class InventarioCabeceraEntityConfig : IEntityTypeConfiguration<InventarioCabecera>
    {
        public void Configure(EntityTypeBuilder<InventarioCabecera> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("inventariocabecera", "logistica");
            builder.Property(x => x.Observacion)
                .HasMaxLength(-1);
            builder.HasOne(ic => ic.DocumentoTipo)
                .WithMany() 
                .HasForeignKey(ic => ic.DocumentoTipoId);
            builder.HasOne(ic => ic.LogisticaTransaccion)
                .WithMany()
                .HasForeignKey(ic => ic.LogisticaTransaccionId);
            builder.HasOne(ic => ic.Almacen)
                .WithMany()
                .HasForeignKey(ic => ic.AlmacenId);
        }
    }
}
