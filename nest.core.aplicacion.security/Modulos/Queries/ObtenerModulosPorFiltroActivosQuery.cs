using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.security.Modulos.Queries;

public record ObtenerModulosPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
