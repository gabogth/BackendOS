namespace nest.core.dominio.Logistica
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int UnidadMedidaCompraId { get; set; }
        public int UnidadMedidaConsumoId { get; set; }
        public decimal Factor { get; set; }
        public bool Activo { get; set; }
        public bool PuedeGenerarNuevosLotes { get; set; }
        public UnidadMedida UnidadMedidaCompra {  get; set; }
        public UnidadMedida UnidadMedidaConsumo { get; set; }
    }
}
