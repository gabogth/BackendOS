using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public class UsuarioGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IUsuarioGenericCommand
    {
        public UsuarioGenericValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("El correo es obligatorio.")
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("Debe ser un correo electrónico válido.");
        }
    }
}
