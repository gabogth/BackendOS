using MediatR;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;

public record ObtenerGrupoTrabajoPersonasPorGrupoQuery(long GrupoTrabajoId) : IRequest<List<GrupoTrabajoPersona>>;
