using FluentValidation;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Behaviors
{
    public class UbicacionTecnicaModificarValidator : AbstractValidator<UbicacionTecnicaModificarCommand>
    {
        public UbicacionTecnicaModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador de la ubicación técnica es obligatorio.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es obligatorio.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.");
        }
    }
}
