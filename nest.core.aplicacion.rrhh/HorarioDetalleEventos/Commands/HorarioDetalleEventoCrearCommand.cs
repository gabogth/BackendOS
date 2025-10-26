using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;

public record HorarioDetalleEventoCrearCommand(
    int EmpresaId,
    long HorarioDetalleId,
    HorarioDetalleEventoTipoEnum TipoEvento,
    TimeOnly Hora,
    int DiferenciaDia,
    int VentanaMin,
    int VentanaMax
) : IRequest<HorarioDetalleEvento>, ICommandBase;
