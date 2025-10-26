using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Queries;

public record ObtenerHorarioDetallePorIdQuery(long Id) : IRequest<HorarioDetalle>;
