using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.logistica.Almacenes.Queries;

public record ObtenerAlmacenesPorFiltroActivoQuery(
    DataSourceLoadOptionsBase options)
    : IRequest<LoadResult>;
