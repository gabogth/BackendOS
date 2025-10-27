using FluentValidation;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Behaviors
{
    public sealed class UsuarioEmpresaEliminarValidator : AbstractValidator<UsuarioEmpresaEliminarCommand>
    {
        public UsuarioEmpresaEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es requerido.");
        }
    }
}
