using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.general.Distritos.Queries;

public record ObtenerDistritosPorFiltroActivosQuery(
    DataSourceLoadOptionsBase options)
    : IRequest<LoadResult>;
