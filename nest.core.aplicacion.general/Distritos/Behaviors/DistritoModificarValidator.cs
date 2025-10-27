using FluentValidation;
using nest.core.aplicacion.general.Distritos.Commands;

namespace nest.core.aplicacion.general.Distritos.Behaviors
{
    public class DistritoModificarValidator : AbstractValidator<DistritoModificarCommand>
    {
        public DistritoModificarValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id es requerido.");
            Include(new DistritoGenericValidator<DistritoModificarCommand>());
        }
    }
}
