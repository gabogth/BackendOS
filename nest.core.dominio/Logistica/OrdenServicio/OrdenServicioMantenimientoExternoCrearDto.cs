namespace nest.core.dominio.Logistica.OrdenServicio
{
    public class OrdenServicioMantenimientoExternoCrearDto : OrdenServicioCabeceraCrearDto
    {
        public string Proveedor { get; set; } = string.Empty;
        public decimal Costo { get; set; }
    }
}
