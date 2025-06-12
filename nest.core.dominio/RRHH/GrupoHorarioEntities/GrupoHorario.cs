using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.RRHH.GrupoHorarioEntities
{
    public class GrupoHorario : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraSalida { get; set; }
        public int DiferenciaDia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
