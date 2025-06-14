namespace nest.core.dominio.RRHH.PersonalEntities
{
    public class PersonalCrearDto
    {
        public int Id { get; set; }
        public bool MarcaAsistencia { get; set; }
        public long ContratoCabeceraId { get; set; }
        public int HorarioCabeceraId { get; set; }
        public int? SuperiorId { get; set; }
        public byte PersonalEstadoId { get; set; }
    }
}
