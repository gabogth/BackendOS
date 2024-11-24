using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Security.Repositorios
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> ObtenerPorEmail(string Email);
        Task<ApplicationUser> ObtenerPorId(string Id);
    }
}
