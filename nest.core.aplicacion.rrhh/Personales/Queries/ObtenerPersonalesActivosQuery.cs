using MediatR;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Queries;

public record ObtenerPersonalesActivosQuery() : IRequest<List<Personal>>;
