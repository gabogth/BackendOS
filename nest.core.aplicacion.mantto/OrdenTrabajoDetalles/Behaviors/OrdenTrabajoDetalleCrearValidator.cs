using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Behaviors
{
    public class OrdenTrabajoDetalleCrearValidator : AbstractValidator<OrdenTrabajoDetalleCrearCommand>
    {
        public OrdenTrabajoDetalleCrearValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es obligatorio.");

            RuleFor(x => x.OrdenTrabajoCabeceraId)
                .GreaterThan(0).WithMessage("La cabecera de orden de trabajo es obligatoria.");

            RuleFor(x => x.UbicacionTecnicaId)
                .GreaterThan(0).WithMessage("La ubicación técnica es obligatoria.");

            RuleFor(x => x.LaborId)
                .GreaterThan(0).WithMessage("La labor es obligatoria.");

            RuleFor(x => x.HorasProyectadas)
                .GreaterThanOrEqualTo(0).WithMessage("Las horas proyectadas deben ser positivas.");

            RuleFor(x => x.HorasEjecutadas)
                .GreaterThanOrEqualTo(0).WithMessage("Las horas ejecutadas deben ser positivas.");
        }
    }
}
