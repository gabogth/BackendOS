using MediatR;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Queries;

public record ObtenerFormularioPorIdQuery(int Id) : IRequest<Formulario>;
