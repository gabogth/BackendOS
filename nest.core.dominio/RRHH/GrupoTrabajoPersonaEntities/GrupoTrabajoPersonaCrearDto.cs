namespace nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities
{
    public class GrupoTrabajoPersonaCrearDto
    {
        public int EmpresaId { get; set; }
        public long? Id { get; set; }
        public long GrupoTrabajoId { get; set; }
        public int PersonaId { get; set; }
        public bool EsLider { get; set; }
    }
}
