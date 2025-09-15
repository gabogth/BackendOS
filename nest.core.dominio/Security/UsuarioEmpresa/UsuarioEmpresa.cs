using Microsoft.AspNetCore.Identity;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Security.UsuarioEmpresa
{
    public class UsuarioEmpresa: IEntity<long>, IAuditable, ITenantEntity
    {
        public long Id { get; set; }
        public string UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public bool Actual { get; set; }
        public IdentityUser Usuario { get; set; }
        public Empresa Empresa { get; set; }
    }
}
