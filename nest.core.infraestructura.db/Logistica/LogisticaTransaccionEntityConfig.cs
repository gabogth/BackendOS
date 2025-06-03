using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Logistica
{
    public class LogisticaTransaccionEntityConfig : IEntityTypeConfiguration<LogisticaTransaccion>
    {
        public void Configure(EntityTypeBuilder<LogisticaTransaccion> builder)
        {
            builder.ToTable("logistica_transaccion", "logistica");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<LogisticaTransaccionValueGenerator>();
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
    public class LogisticaTransaccionValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<LogisticaTransaccion>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<LogisticaTransaccion>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
