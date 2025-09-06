using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Logistica
{
    public class LogisticaTransaccion : IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string ES { get; set; }
    }
}
