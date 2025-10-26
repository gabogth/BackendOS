using FluentValidation;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Commands;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Behaviors
{
    public class OrigenFinancieroModificarValidator : AbstractValidator<OrigenFinancieroModificarCommand>
    {
        public OrigenFinancieroModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((short)0).WithMessage("El identificador debe ser mayor a 0.");

            Include(new OrigenFinancieroCrearValidator());
        }
    }
}
