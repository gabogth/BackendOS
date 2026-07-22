using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;

public record ObtenerGrupoTrabajoPersonasPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
