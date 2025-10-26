using MediatR;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Queries;

public record ObtenerCargoPorIdQuery(int Id) : IRequest<Cargo>;
