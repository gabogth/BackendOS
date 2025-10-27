using FluentValidation;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Behaviors
{
    public sealed class UsuarioEmpresaModificarValidator : AbstractValidator<UsuarioEmpresaModificarCommand>
    {
        public UsuarioEmpresaModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es requerido.");
            Include(new UsuarioEmpresaGenericValidator<UsuarioEmpresaModificarCommand>());
        }
    }
}
