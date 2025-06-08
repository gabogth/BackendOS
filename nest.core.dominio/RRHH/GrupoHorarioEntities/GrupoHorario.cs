using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.GrupoHorarioEntities
{
    public class GrupoHorario : IAuditable
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
