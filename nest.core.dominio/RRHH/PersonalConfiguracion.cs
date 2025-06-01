using nest.core.dominio.Legal;

namespace nest.core.dominio.RRHH
{
    public class PersonalConfiguracion
    {
        public int Id { get; set; }
        public int ContratoCabeceraId { get; set; }
        public bool MarcaAsistencia { get; set; }
        public int HorarioCabeceraId { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
        public Personal Personal { get; set; }
    }
}
