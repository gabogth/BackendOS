using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.PuntoFinancieroEntities
{
    public class PuntoFinanciero : IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
    }
}
