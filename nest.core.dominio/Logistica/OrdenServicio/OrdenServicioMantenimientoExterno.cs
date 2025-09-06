namespace nest.core.dominio.Logistica.OrdenServicio
{
    public class OrdenServicioMantenimientoExterno : OrdenServicioCabecera
    {
        public string Proveedor { get; set; } = string.Empty;
        public decimal Costo { get; set; }
    }
}
