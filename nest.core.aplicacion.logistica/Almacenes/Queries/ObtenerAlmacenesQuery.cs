using MediatR;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Queries;

public record ObtenerAlmacenesQuery() : IRequest<List<Almacen>>;
