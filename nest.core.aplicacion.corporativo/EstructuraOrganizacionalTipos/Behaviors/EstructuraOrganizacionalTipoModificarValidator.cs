using FluentValidation;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Behaviors
{
    public class EstructuraOrganizacionalTipoModificarValidator : AbstractValidator<EstructuraOrganizacionalTipoModificarCommand>
    {
        public EstructuraOrganizacionalTipoModificarValidator()
        {
            Include(new EstructuraOrganizacionalTipoCrearValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a cero.");
        }
    }
}
