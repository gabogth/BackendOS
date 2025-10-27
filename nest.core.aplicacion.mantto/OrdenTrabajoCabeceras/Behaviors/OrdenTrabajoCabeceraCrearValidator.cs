using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Behaviors
{
    public class OrdenTrabajoCabeceraCrearValidator : AbstractValidator<OrdenTrabajoCabeceraCrearCommand>
    {
        public OrdenTrabajoCabeceraCrearValidator()
        {
            Include(new OrdenTrabajoCabeceraGenericValidator<OrdenTrabajoCabeceraCrearCommand>());
        }
    }
}
