using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Security.Auth
{
    public class LoginDto
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
        public string? TwoFactorCode { get; init; }
        public string? TwoFactorRecoveryCode { get; init; }
        public required string TenantId { get; init; }
}
}
