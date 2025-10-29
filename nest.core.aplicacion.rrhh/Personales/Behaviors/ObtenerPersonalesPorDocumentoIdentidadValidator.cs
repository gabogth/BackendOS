using FluentValidation;
using nest.core.aplicacion.rrhh.Personales.Queries;

namespace nest.core.aplicacion.rrhh.Personales.Behaviors
{
    public class ObtenerPersonalesPorDocumentoIdentidadValidator : AbstractValidator<ObtenerPersonalesPorDocumentoIdentidadQuery>
    {
        public ObtenerPersonalesPorDocumentoIdentidadValidator()
        {
            RuleFor(x => x.tipoDocumentoId)
                .GreaterThan(0).NotNull().WithMessage("El tipo de documento de identidad es obligatorio.");
            RuleFor(x => x.documentoIdentidad)
                .NotEmpty().NotNull().WithMessage("El documento de identidad es obligatorio.");
        }
    }
}
