using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.infraestructura.db.Aplicacion
{
    public class ModuloEntityConfig : IEntityTypeConfiguration<Modulo>
    {
        public static readonly string SCHEMA = "aplicacion";
        public static readonly string TABLE = "modulo";
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<ModuloValueGenerator>();
            builder.ToTable(TABLE, SCHEMA);
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Descripcion)
                .HasMaxLength(-1);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<Modulo> ObtenerInformacionInicial()
        {
            List<Modulo> roles = new List<Modulo>()
            {
                new Modulo { Id = 1, Nombre = "Seguridad", NombreCorto = "SECURITY", Descripcion = "Modulo donde se setean los roles, permisos y menús.", Controlador = "Seguridad", Action = "Index", Estado = true, RutaImagen = "" },
                new Modulo { Id = 2, Nombre = "Logistica", NombreCorto = "LOGISTIC", Descripcion = "Modulo de inventarios logistica y transferencias.", Controlador = "Logistica", Action = "Index", Estado = true, RutaImagen = "" },
                new Modulo { Id = 3, Nombre = "Ventas", NombreCorto = "VENTAS", Descripcion = "Modulo de facturacion, ventas, caja.", Controlador = "VentasHome", Action = "Index", Estado = true, RutaImagen = "" },
                new Modulo { Id = 4, Nombre = "Contabilidad", NombreCorto = "CONTABIL", Descripcion = "Modulo de libro diario, asientos, libro mayor.", Controlador = "Contabilidad", Action = "Index", Estado = true, RutaImagen = "" },
                new Modulo { Id = 5, Nombre = "Produccion", NombreCorto = "PRODUCCI", Descripcion = "Modulo de producción, recetas, conversiones.", Controlador = "Produccion", Action = "Index", Estado = true, RutaImagen = "" }
            };
            return roles;
        }
    }
    public class ModuloValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, ModuloEntityConfig.SCHEMA, ModuloEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, ModuloEntityConfig.SCHEMA, ModuloEntityConfig.TABLE, cancellationToken);
    }
}
