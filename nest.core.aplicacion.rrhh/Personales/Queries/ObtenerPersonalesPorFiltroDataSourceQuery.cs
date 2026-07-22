using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.Personales.Queries;

public record ObtenerPersonalesPorFiltroDataSourceQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
