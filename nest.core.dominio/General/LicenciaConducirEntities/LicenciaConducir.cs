using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.LicenciaConducirEntities
{
    public class LicenciaConducir : IAuditable
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public byte Nivel { get; set; }
    }
}
