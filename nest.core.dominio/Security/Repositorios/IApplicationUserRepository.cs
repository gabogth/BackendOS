namespace nest.core.dominio.Security.Repositorios
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> ObtenerPorEmail(string Email);
        Task<ApplicationUser> ObtenerPorId(string Id);
    }
}
