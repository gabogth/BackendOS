using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Security.Dto
{
    public record CreateUserDto(
        string Email,
        string Password,
        string Empresa,
        string Direccion
    );
}
