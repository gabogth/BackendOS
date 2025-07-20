using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Costos.CentroDeCostosEntities
{
    public class CentroDeCostos: IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Codigo { get; set; }
        public bool EsFinal { get; set; }
        public int? PadreId { get; set; }
        public bool Activo { get; set; }
        public CentroDeCostos Padre { get; set; }
        public List<CentroDeCostos> Children { get; set; }
    }
}
