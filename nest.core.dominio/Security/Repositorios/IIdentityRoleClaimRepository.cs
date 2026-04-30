using Microsoft.AspNetCore.Identity;
using nest.core.dominio.Security.Dto;

namespace nest.core.dominio.Security.Repositorios
{
    public interface IIdentityRoleClaimRepository
    {
        Task AgregarRange(List<IdentityRoleClaim<string>> entries);
        Task EliminarPorRolId(string roleId);
        Task MergeRange(string roleId, IReadOnlyCollection<ClaimDto> entries);
    }
}
