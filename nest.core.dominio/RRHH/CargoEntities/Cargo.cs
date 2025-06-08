using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.CargoEntities
{
    public class Cargo : IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
