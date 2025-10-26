using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<DocumentoIdentidadTipo>>, IQueryBase;
}
