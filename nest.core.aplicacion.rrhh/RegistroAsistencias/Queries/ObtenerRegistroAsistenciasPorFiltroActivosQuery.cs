using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Queries;

public record ObtenerRegistroAsistenciasPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
