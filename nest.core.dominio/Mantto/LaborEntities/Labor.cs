using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.LaborEntities
{
    public class Labor : IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
    }
}
