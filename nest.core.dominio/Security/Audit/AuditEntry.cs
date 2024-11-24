using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace nest.core.dominio.Security.Audit
{
    public class AuditEntry
    {
        public EntityEntry Entidad { get; }
        public string EntidadId { get; set; }
        public string Tabla { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public Dictionary<string, object> OldValues { get; set; }
        public Dictionary<string, object> NewValues { get; set; }

        public AuditEntry(EntityEntry entidad)
        {
            Entidad = entidad;
            OldValues = new Dictionary<string, object>();
            NewValues = new Dictionary<string, object>();
        }

        public AuditLog ToAuditLog()
        {
            return new AuditLog
            {
                EntidadNombre = Tabla,
                Accion = Accion,
                Fecha = Fecha,
                OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),
                Usuario = Usuario,
                EntidadId = EntidadId
            };
        }
    }
}
