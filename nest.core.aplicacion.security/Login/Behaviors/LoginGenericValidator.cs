using FluentValidation;
using nest.core.aplicacion.security.Login.Commands;

namespace nest.core.aplicacion.security.Login.Behaviors;

public class LoginGenericValidator<TCommand> : AbstractValidator<TCommand>
    where TCommand : ILoginEmailCommand
{
    public LoginGenericValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty().WithMessage("El correo es obligatorio.")
            .EmailAddress().WithMessage("El correo no tiene un formato válido.");
    }
}
