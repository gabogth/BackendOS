using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<DocumentoTipo>>, IQueryBase;
}
