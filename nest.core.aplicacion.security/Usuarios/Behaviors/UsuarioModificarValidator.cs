using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public sealed class UsuarioModificarValidator : AbstractValidator<UsuarioModificarCommand>
    {
        public UsuarioModificarValidator()
        {
            RuleFor(x => x.Usuario)
                .NotNull().WithMessage("El usuario es requerido.");

            When(x => x.Usuario is not null, () =>
            {
                RuleFor(x => x.Usuario.Id)
                    .NotEmpty().WithMessage("El identificador del usuario es requerido.");

                RuleFor(x => x.Usuario.Email)
                    .NotEmpty().WithMessage("El correo es requerido.")
                    .EmailAddress().WithMessage("El correo no es válido.");
            });
        }
    }
}
