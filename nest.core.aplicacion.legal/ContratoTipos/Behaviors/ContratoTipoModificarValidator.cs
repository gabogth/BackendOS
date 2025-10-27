using FluentValidation;
using nest.core.aplicacion.legal.ContratoTipos.Commands;

namespace nest.core.aplicacion.legal.ContratoTipos.Behaviors
{
    public class ContratoTipoModificarValidator : AbstractValidator<ContratoTipoModificarCommand>
    {
        public ContratoTipoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((byte)0).WithMessage("El identificador debe ser mayor a 0.");
            Include(new ContratoTipoGenericValidator<ContratoTipoModificarCommand>());
        }
    }
}
