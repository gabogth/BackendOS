using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Queries;

public record ObtenerHorarioDetalleEventoPorIdQuery(long Id) : IRequest<HorarioDetalleEvento>;
