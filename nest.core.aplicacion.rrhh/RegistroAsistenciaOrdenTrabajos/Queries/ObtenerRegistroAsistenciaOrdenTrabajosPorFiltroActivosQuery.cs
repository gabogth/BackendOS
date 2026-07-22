using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Queries;

public record ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
