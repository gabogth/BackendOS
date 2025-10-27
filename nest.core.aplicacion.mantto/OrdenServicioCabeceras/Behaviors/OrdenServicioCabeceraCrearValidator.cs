using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Behaviors
{
    public class OrdenServicioCabeceraCrearValidator : AbstractValidator<OrdenServicioCabeceraCrearCommand>
    {
        public OrdenServicioCabeceraCrearValidator()
        {
            Include(new OrdenServicioCabeceraGenericValidator<OrdenServicioCabeceraCrearCommand>());
        }
    }
}
