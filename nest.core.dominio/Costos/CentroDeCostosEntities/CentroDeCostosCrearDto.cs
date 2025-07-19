namespace nest.core.dominio.Costos.CentroDeCostosEntities
{
    public class CentroDeCostosCrearDto
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Codigo { get; set; }
        public string EsFinal { get; set; }
        public int PadreId { get; set; }
    }
}
