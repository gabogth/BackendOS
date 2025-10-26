using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Queries;

public record ObtenerHorarioDetalleEventosQuery() : IRequest<List<HorarioDetalleEvento>>;
