namespace nest.core.dominio.RRHH.GrupoHorarioEntities
{
    public class GrupoHorarioCrearDto
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraSalida { get; set; }
        public int DiferenciaDia { get; set; }
    }
}
