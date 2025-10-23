using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.PersonaAdjuntoEntities
{
    public class PersonaAdjunto : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public int PersonaId { get; set; }
        public long AdjuntoId { get; set; }
        public AdjuntoTipoEnum AdjuntoTipoId { get; set; }
        public bool EsFotoPrincipal { get; set; }
        public Persona Persona { get; set; }
        public Adjunto Adjunto { get; set; }
        public AdjuntoTipo AdjuntoTipo { get; set; }
    }
}
