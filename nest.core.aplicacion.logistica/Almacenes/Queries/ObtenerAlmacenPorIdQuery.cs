using MediatR;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Queries;

public record ObtenerAlmacenPorIdQuery(int Id) : IRequest<Almacen>;
