using FluentValidation;
using nest.core.aplicacion.security.Login.Commands;

namespace nest.core.aplicacion.security.Login.Behaviors;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        Include(new LoginGenericValidator<LoginCommand>());

        RuleFor(command => command.Password)
            .NotEmpty().WithMessage("La contraseña es obligatoria.")
            .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
    }
}
