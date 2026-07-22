using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Queries;

public record ObtenerGrupoTrabajosPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
