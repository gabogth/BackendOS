using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Costos.CentroDeCostosEntities
{
    public class CentroDeCostos: IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Codigo { get; set; }
        public string EsFinal { get; set; }
        public int PadreId { get; set; }
        public CentroDeCostos Padre { get; set; }
        public List<CentroDeCostos> Children { get; set; }
    }
}
