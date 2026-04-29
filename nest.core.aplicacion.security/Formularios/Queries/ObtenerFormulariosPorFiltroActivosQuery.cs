using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;

namespace nest.core.aplicacion.security.Formularios.Queries;

public record ObtenerFormulariosPorFiltroActivosQuery(
    DataSourceLoadOptionsBase options) 
    : IRequest<LoadResult>;
