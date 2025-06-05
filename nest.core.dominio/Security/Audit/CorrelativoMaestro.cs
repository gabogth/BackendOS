namespace nest.core.dominio.Security.Audit
{
    public class CorrelativoMaestro
    {
        public string Schema { get; set; }
        public string Table { get; set; }
        public long LastValue { get; set; }
    }
}
