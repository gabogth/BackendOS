using Microsoft.AspNetCore.Identity;

namespace nest.core.dominio.Security.Repositorios
{
    public interface IIdentityRoleUserRepository
    {
        Task AgregarRange(List<IdentityUserRole<string>> entries);
        Task EliminarPorRolId(string roleId);
        Task MergeRange(string roleId, IReadOnlyCollection<string> usersId);
    }
}
