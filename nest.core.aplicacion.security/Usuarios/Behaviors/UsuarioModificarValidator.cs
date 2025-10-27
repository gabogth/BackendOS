using FluentValidation;
using nest.core.aplicacion.security.Usuarios.Commands;

namespace nest.core.aplicacion.security.Usuarios.Behaviors
{
    public sealed class UsuarioModificarValidator : AbstractValidator<UsuarioModificarCommand>
    {
        public UsuarioModificarValidator()
        {
            Include(new UsuarioGenericValidator<UsuarioModificarCommand>());

            When(x => x.Usuario is not null, () =>
            {
                RuleFor(x => x.Usuario.Id)
                    .NotEmpty().WithMessage("El identificador del usuario es requerido.");
            });
        }
    }
}
