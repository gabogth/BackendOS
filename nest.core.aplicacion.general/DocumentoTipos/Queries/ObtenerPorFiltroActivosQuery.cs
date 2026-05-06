using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using nest.core.aplicacion.utils.Queries;

namespace nest.core.aplicacion.general.DocumentoTipos.Queries
{
    public sealed record ObtenerPorFiltroActivosQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>, IQueryBase;
}
