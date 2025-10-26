using MediatR;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Queries;

public record ObtenerCargosQuery() : IRequest<List<Cargo>>;
