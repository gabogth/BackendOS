namespace nest.core.dominio.Security.Audit
{
    public class CorrelativoMaestroTenant
    {
        public string Schema { get; set; }
        public string Table { get; set; }
        public int EmpresaId { get; set; }
        public long LastValue { get; set; }
    }
}
