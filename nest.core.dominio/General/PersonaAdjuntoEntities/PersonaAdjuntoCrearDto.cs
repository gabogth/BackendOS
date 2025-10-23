using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.dominio.General.PersonaAdjuntoEntities
{
    public class PersonaAdjuntoCrearDto
    {
        public long Id { get; set; }
        public int PersonaId { get; set; }
        public long AdjuntoId { get; set; }
        public AdjuntoTipoEnum AdjuntoTipoId { get; set; }
        public bool EsFotoPrincipal { get; set; }
    }
}
