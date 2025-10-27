using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Commands;

public record HorarioDetalleCrearCommand(
    int EmpresaId,
    int HorarioCabeceraId,
    DayOfWeek DiaSemana
) : IRequest<HorarioDetalle>, IHorarioDetalleGenericCommand;
