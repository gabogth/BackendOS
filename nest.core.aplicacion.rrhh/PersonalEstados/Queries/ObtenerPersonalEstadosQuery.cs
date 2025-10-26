using MediatR;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Queries;

public record ObtenerPersonalEstadosQuery() : IRequest<List<PersonalEstado>>;
