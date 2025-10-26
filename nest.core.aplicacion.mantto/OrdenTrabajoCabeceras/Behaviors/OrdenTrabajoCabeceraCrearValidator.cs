using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Behaviors
{
    public class OrdenTrabajoCabeceraCrearValidator : AbstractValidator<OrdenTrabajoCabeceraCrearCommand>
    {
        public OrdenTrabajoCabeceraCrearValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es requerida.");

            RuleFor(x => x.OrdenServicioCabeceraId)
                .GreaterThan(0).WithMessage("La orden de servicio es requerida.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(200).WithMessage("El nombre no debe exceder 200 caracteres.");

            RuleFor(x => x.FechaCompromiso)
                .GreaterThanOrEqualTo(x => x.FechaInicio).WithMessage("La fecha de compromiso debe ser posterior a la fecha de inicio.");

            When(x => x.FechaFin.HasValue, () =>
            {
                RuleFor(x => x.FechaFin)
                    .GreaterThanOrEqualTo(x => x.FechaInicio)
                    .WithMessage("La fecha fin debe ser posterior a la fecha de inicio.");
            });

            RuleFor(x => x.Estado)
                .IsInEnum().WithMessage("El estado seleccionado no es válido.");
        }
    }
}
