using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;

namespace nest.core.infraestructura.db.Logistica
{
    public class LogisticaTransaccionEntityConfig : IEntityTypeConfiguration<LogisticaTransaccion>
    {
        public static readonly string SCHEMA = "logistica";
        public static readonly string TABLE = "logistica_transaccion";
        public void Configure(EntityTypeBuilder<LogisticaTransaccion> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.ES)
                .HasMaxLength(1);
            builder.HasData(GetData());
        }

        private List<LogisticaTransaccion> GetData()
        {
            return new List<LogisticaTransaccion>
            {
                new LogisticaTransaccion { Id = 1, Nombre = "INGRESO POR COMPRA", NombreCorto = "ICOMPRA", ES = "E"},
                new LogisticaTransaccion { Id = 2, Nombre = "INGRESO POR INICIO DE OPERACIONES", NombreCorto = "IOPERAC", ES = "E" },
                new LogisticaTransaccion { Id = 3, Nombre = "INGRESO POR DIFERENCIA DE INVENTARIO", NombreCorto = "IDIFINV", ES = "E" },
                new LogisticaTransaccion { Id = 4, Nombre = "INGRESO POR TRANFERENCIA", NombreCorto = "ITRANSF", ES = "E" },
                new LogisticaTransaccion { Id = 5, Nombre = "INGRESO POR PRODUCCION", NombreCorto = "IPRODUC", ES = "E" },
                new LogisticaTransaccion { Id = 101, Nombre = "SALIDA POR VENTA", NombreCorto = "SVENTA", ES = "S" },
                new LogisticaTransaccion { Id = 102, Nombre = "SALIDA POR CIERRE DE OPERACIONES", NombreCorto = "SOPERAC", ES = "S" },
                new LogisticaTransaccion { Id = 103, Nombre = "SALIDA POR DIFERENCIA DE INVENTARIO", NombreCorto = "SDIFINV", ES = "S" },
                new LogisticaTransaccion { Id = 104, Nombre = "SALIDA POR TRANSFERENCIA", NombreCorto = "STRANSF", ES = "S" },
                new LogisticaTransaccion { Id = 105, Nombre = "SALIDA POR PRODUCCION", NombreCorto = "SPRODUC", ES = "E" },
            };
        }
    }
}
