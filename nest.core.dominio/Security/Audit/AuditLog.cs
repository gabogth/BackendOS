namespace nest.core.dominio.Security.Audit
{
    public class AuditLog
    {
        public long Id { get; set; }
        public string EntidadNombre { get; set; }
        public string EntidadId { get; set; }
        public string Accion { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
