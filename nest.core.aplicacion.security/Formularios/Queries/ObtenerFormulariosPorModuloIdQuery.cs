using MediatR;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Queries;

public record ObtenerFormulariosPorModuloIdQuery(int ModuloId) : IRequest<List<Formulario>>;
