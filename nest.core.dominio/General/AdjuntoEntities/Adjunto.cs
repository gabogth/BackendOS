using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.AdjuntoEntities
{
    public class Adjunto: IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public AdjuntoProviderEnum AdjuntoProvider { get; set; }
        public string Container { get; set; }
        public string FullPath { get; set; }
        public string NombreGenerado { get; set; }
        public PersonaAdjunto PersonaAdjunto { get; set; }
        public RegistroAsistenciaAdjunto RegistroAsistenciaAdjunto { get; set; }
    }
}
