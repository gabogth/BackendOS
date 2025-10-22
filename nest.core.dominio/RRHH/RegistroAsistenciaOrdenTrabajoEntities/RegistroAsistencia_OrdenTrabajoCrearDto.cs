using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities
{
    public class RegistroAsistencia_OrdenTrabajoCrearDto: RegistroAsistenciaCrearDto
    {
        public long OrdenTrabajoCabeceraId { get; set; }
    }
}
