using MediatR;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.aplicacion.security.Modulos.Queries;

public record ObtenerModulosPorFiltroQuery(IReadOnlyDictionary<string, object?> Filtros) : IRequest<List<Modulo>>;
