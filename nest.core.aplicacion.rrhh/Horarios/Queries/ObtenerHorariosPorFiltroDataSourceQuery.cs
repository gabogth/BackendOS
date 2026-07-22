using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.rrhh.Horarios.Queries
{
    public record ObtenerHorariosPorFiltroDataSourceQuery(DataSourceLoadOptionsBase options) : IRequest<LoadResult>;
}
