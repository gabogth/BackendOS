using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public sealed class UsuarioEliminarValidator : AbstractValidator<UsuarioEliminarCommand>
    {
        public UsuarioEliminarValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty().WithMessage("El identificador del usuario es requerido.");
        }
    }
}
