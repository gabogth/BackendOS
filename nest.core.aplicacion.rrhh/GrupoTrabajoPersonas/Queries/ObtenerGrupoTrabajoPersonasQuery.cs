using MediatR;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;

public record ObtenerGrupoTrabajoPersonasQuery() : IRequest<List<GrupoTrabajoPersona>>;
