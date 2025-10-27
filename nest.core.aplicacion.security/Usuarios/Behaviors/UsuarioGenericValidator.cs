using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public class UsuarioGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IUsuarioGenericCommand
    {
        public UsuarioGenericValidator()
        {
            RuleFor(x => x.Usuario)
                .NotNull().WithMessage("El usuario es requerido.");

            When(x => x.Usuario is not null, () =>
            {
                RuleFor(x => x.Usuario.Email)
                    .NotEmpty().WithMessage("El correo es requerido.")
                    .EmailAddress().WithMessage("El correo no es válido.");
            });
        }
    }
}
