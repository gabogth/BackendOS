using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public class HorarioDetalle
    {
        public int Id { get; set; }
        public int HorarioCabeceraId { get; set; }
        public byte DiaSemana { get; set; }
        public int GrupoHorarioId { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }
        public GrupoHorario GrupoHorario { get; set; }
    }
}
