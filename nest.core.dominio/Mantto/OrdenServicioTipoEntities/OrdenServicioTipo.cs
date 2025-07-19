using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenServicioTipoEntities
{
    public class OrdenServicioTipo : IEntity<short>, IAuditable
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Estado { get; set; }

    }
}
