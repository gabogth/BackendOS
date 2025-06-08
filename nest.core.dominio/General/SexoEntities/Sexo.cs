using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.SexoEntities
{
    public class Sexo: IAuditable
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
    }
}
