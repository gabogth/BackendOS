using MediatR;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.aplicacion.security.Modulos.Queries;

public record ObtenerModuloPorIdQuery(int Id) : IRequest<Modulo>;
