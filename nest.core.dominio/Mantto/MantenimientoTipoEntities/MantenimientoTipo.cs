using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.MantenimientoTipoEntities
{
    public class MantenimientoTipo : IEntity<short>, IAuditable
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
    }
}
