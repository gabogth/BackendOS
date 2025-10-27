using FluentValidation;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Behaviors
{
    public sealed class UsuarioEmpresaCrearValidator : AbstractValidator<UsuarioEmpresaCrearCommand>
    {
        public UsuarioEmpresaCrearValidator()
        {
            Include(new UsuarioEmpresaGenericValidator<UsuarioEmpresaCrearCommand>());
        }
    }
}
