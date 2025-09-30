using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities
{
    public class RegistroAsistenciaPolitica : ITenantEntity, IAuditable, IEntity<long>
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public int MinutosTardanzaIngreso { get; set; }
        public int MinutosExtra { get; set; }
        public int MinutosExtraEntrada { get; set; }
        public bool TieneCompletarHora { get; set; }
    }
}
