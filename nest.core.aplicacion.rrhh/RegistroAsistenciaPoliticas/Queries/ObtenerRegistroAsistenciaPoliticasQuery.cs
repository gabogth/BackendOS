using MediatR;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Queries;

public record ObtenerRegistroAsistenciaPoliticasQuery : IRequest<List<RegistroAsistenciaPolitica>>;
