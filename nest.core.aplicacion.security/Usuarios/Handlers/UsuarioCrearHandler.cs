using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Usuarios.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Handlers
{
    public sealed class UsuarioCrearHandler : IRequestHandler<UsuarioCrearCommand, ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<UsuarioCrearHandler> logger;

        public UsuarioCrearHandler(UserManager<ApplicationUser> userManager, ILogger<UsuarioCrearHandler> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<ApplicationUser> Handle(UsuarioCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ApplicationUser usuario = new ApplicationUser
                {
                    UserName = request.Email,
                    NormalizedUserName = request.Email?.ToUpperInvariant(),
                    NormalizedEmail = request.Email?.ToUpperInvariant(),
                    PhoneNumber = request.PhoneNumber
                };
                IdentityResult result = await userManager.CreateAsync(usuario, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
                }

                return await userManager.FindByNameAsync(usuario.UserName!)
                    ?? throw new InvalidOperationException("No fue posible obtener el usuario creado.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear el usuario {Email}", request.Email);
                throw;
            }
        }
    }
}
