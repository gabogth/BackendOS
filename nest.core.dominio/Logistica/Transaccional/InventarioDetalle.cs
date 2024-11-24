namespace nest.core.dominio.Logistica.Transaccional
{
    public class InventarioDetalle
    {
        public long Id { get; set; }
        public long InventarioCabeceraId { get; set; }
        public short Item { get; set; }
        public int ProductoId { get; set; }
        public long ProductoLoteId { get; set; }
        public Producto Producto { get; set; }
        public ProductoLote ProductoLote { get; set; }
        public int Cantidad { get; set; }
        public string Nota { get; set; }
        public InventarioCabecera InventarioCabecera { get; set; }
    }
}
