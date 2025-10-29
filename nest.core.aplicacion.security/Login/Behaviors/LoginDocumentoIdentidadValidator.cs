using FluentValidation;
using nest.core.aplicacion.security.Login.Commands;

namespace nest.core.aplicacion.security.Login.Behaviors
{
    public class LoginDocumentoIdentidadValidator : AbstractValidator<LoginDocumentoIdentidadCommand>
    {
        public LoginDocumentoIdentidadValidator()
        {
            RuleFor(x => x.tipoDocumentoId)
                .GreaterThan(0).NotNull().WithMessage("El tipo de documento de identidad es obligatorio.");
            RuleFor(x => x.documentoIdentidad)
                .NotEmpty().NotNull().WithMessage("El documento de identidad es obligatorio.");
        }
    }
}
