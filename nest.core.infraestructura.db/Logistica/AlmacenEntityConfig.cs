using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.infraestructura.db.Logistica
{
    public class AlmacenEntityConfig : IEntityTypeConfiguration<Almacen>
    {
        public void Configure(EntityTypeBuilder<Almacen> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("almacen", "logistica");
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Direccion)
            .HasMaxLength(255);
            builder.Property(x => x.Latitud)
                .HasPrecision(9, 6);
            builder.Property(x => x.Longitud)
                .HasPrecision(9, 6);
            builder.HasOne(x => x.Distrito)
                .WithMany()
                .HasForeignKey(x => x.DistritoId)
                .OnDelete(DeleteBehavior.Restrict); 
            builder.HasData(GetData());
        }

        private List<Almacen> GetData()
        {
            return new List<Almacen>
            {
                new Almacen { Id = 1, Nombre = "DEFAULT 1", NombreCorto = "DEFAULT1", Activo = true, Direccion = "Av. Default 1", Latitud = 0, Longitud = 0, DistritoId = 1 },
                new Almacen { Id = 2, Nombre = "DEFAULT 2", NombreCorto = "DEFAULT2", Activo = true, Direccion = "Av. Default 2", Latitud = 0, Longitud = 0, DistritoId = 1 },
                new Almacen { Id = 3, Nombre = "DEFAULT 3", NombreCorto = "DEFAULT3", Activo = true, Direccion = "Av. Default 3", Latitud = 0, Longitud = 0, DistritoId = 1 }
            };
        }
    }
}
