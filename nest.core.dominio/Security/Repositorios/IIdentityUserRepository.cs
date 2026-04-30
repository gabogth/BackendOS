using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Security.Repositorios
{
    public interface IIdentityUserRepository
    {
        Task<List<Claim>> ObtenerClaims(string userId, CancellationToken cancellationToken);
    }
}
