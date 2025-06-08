using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public class HorarioCabecera : IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public List<HorarioDetalle> HorarioDetalles { get; set; } = new List<HorarioDetalle>();
    }
}
