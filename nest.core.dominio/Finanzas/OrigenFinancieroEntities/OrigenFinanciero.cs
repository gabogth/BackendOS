using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.OrigenFinancieroEntities
{
    public class OrigenFinanciero : IEntity<short>, IAuditable
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Naturaleza { get; set; }
        public bool Activo { get; set; }
    }
}
