using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.TerminalBiometricoEntities
{
    public class TerminalBiometrico : ITenantEntity, IAuditable, IEntity<int>
    {
        public int EmpresaId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SN { get; set; }

    }
}
