using nest.core.dominio.Finanzas;

namespace nest.core.dominio.Logistica
{
    public class ProductoLote
    {
        public long Id { get; set; }
        public int ProductoId { get; set; }
        public int SerialId { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int MonedaId { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioConsumo { get; set; }
        public long? InventarioDetalleCreacionId { get; set; }
        public Moneda Moneda { get; set; }
        public Producto Producto { get; set; }
    }
}
