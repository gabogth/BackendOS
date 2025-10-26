using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Queries;

public record ObtenerHorarioDetallesQuery() : IRequest<List<HorarioDetalle>>;
