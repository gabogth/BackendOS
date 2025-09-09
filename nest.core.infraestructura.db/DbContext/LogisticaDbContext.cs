using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.dominio.Logistica.Transaccional;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<LogisticaTransaccion> LogisticaTransaccion { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoLote> ProductoLote { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<InventarioCabecera> InventarioCabecera { get; set; }
        public DbSet<InventarioDetalle> InventarioDetalle { get; set; }
    }
}
