using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public class HorarioCabecera : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public List<HorarioDetalle> HorarioDetalles { get; set; } = new List<HorarioDetalle>();
    }
}
