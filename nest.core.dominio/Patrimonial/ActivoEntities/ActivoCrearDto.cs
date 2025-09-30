namespace nest.core.dominio.Patrimonial.ActivoEntities
{
    public class ActivoCrearDto
    {
        public int EmpresaId { get; set; }
        public long? ProductoLoteId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? DepreciacionMeses { get; set; }
        public int? CentroDeCostosId { get; set; }
        public string ImagenUrl { get; set; }
        public int? TerceroId { get; set; }
    }
}
