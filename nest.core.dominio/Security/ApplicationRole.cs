using Microsoft.AspNetCore.Identity;

namespace nest.core.dominio.Security
{
    public class ApplicationRole : IdentityRole, ITenantEntity
    {
        public int EmpresaId { get; set; }
    }
}
