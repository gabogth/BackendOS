using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public class HorarioCabecera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public List<HorarioDetalle> HorarioDetalles { get; set; } = new List<HorarioDetalle>();
    }
}
