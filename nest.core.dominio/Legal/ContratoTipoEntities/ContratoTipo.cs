using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Legal.ContratoTipoEntities
{
    public class ContratoTipo : IAuditable
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
    }
}
